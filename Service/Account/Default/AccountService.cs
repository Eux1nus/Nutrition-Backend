using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using Services.Code;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

using Domain;
using Domain.Enum;
using Domain.Enums;

namespace Services.Account.Default
{

    public class AccountService : IAccountService
    {
        private IUserRepository UserRepository { get; set; }
        private IActivationCodeRepository ActivationCodeRepository { get; set; }
        private IActivationCodeService ActivationCodeService { get; set; }

        public AccountService(IUserRepository userRepository, IActivationCodeService activationCodeService,
            IActivationCodeRepository activationCodeRepository)

        {
            UserRepository = userRepository;
            ActivationCodeRepository = activationCodeRepository;
            ActivationCodeService = activationCodeService;
        }

        public async Task<SignInDTO> Auth(AuthDTO request)
        {
            var login = PhoneHelper.Clear(request.Login);

            var user = await UserRepository
                .GetAll()
                .Include(x => x.Person)
                .Where(x => x.Login == login
                         && x.Password == CryptHelper.CreateMD5(request.Password))
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(105);

            if (!user.IsActivated)
                throw new ServiceErrorException(111);

            var identity = TokenHelper.GetIdentity(user);
            var token = TokenHelper.GetSecurityToken(identity, false);
            return new SignInDTO(user, token);
        }
        public async Task<SignInDTO> Registration(CreatePersonDTO createPerson)
        {
            var phone = PhoneHelper.Clear(createPerson.PhoneNumber);

            var user = await UserRepository
                .GetAll()
                .Where(x => x.Login.Equals(phone))
                .FirstOrDefaultAsync();

            if (user != null)
                throw new ServiceErrorException(110);

            if (createPerson.Password.Length < 6)
                throw new ServiceErrorException(102);

            var activationCode = await ActivationCodeRepository
                .GetAll()
                .Where((x => x.Number.Equals(phone)
                          && x.PhoneNumberType == PhoneNumberType.Registration
                          && x.IsConfirmed == true))
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(106);

            var newUser = new User
            {
                Login = phone,
                Password = CryptHelper.CreateMD5(createPerson.Password),
                UserRole = UserRole.Default,
                DateRegistration = DateTime.UtcNow,
                IsActivated = true,
                
                Person = new Person
                {
                    Name = createPerson.Name,
                    SurName = createPerson.SurName,
                    PhoneNumber = phone,
                    DateOfBirth = createPerson.DateOfBirth,
                    Email = createPerson.Email,
                    SexType = createPerson.SexType,
                    AgreementIsChecked = false,
                }
            };
            await UserRepository.CreateAsync(newUser);
            await UserRepository.SaveChangesAsync();

            var identity = TokenHelper.GetIdentity(newUser);
            var token = TokenHelper.GetSecurityToken(identity, false);
             
            return new SignInDTO(newUser, token);
        }

        public async Task<UserDTO> UpdateUser(CreatePersonDTO request, User user)
        {
            user.Person.Name = request.Name;
            user.Person.SurName = request.SurName;
            user.Person.DateOfBirth = request.DateOfBirth;
            user.Person.Email = request.Email;
            user.Person.PhoneNumber = request.PhoneNumber;
            user.Person.SexType = request.SexType;

            UserRepository.Update(user);
            await UserRepository.SaveChangesAsync();

            return new UserDTO(user);
        }

        public async Task SendCode(string phoneNumber, PhoneNumberType type)
        {
            await ActivationCodeService.Create(phoneNumber, type);
        }

        public async Task ActivationCode(string phoneNumber, string code, PhoneNumberType type)
        {
            await ActivationCodeService.Check(code, phoneNumber, type);
        }

        public async Task RestorePassword(CreateNewPasswordDTO request)
        {

            if (request.NewPassword.Length < 6)
                throw new ServiceErrorException(108);

            var phone = PhoneHelper.Clear(request.PhoneNumber);

            var activationCode = await ActivationCodeRepository
                .GetAll()
                .Where(x => x.Number == phone
                         && x.PhoneNumberType == PhoneNumberType.ChangePassword
                         && x.IsConfirmed == true)
                .FirstOrDefaultAsync();

            if (activationCode == null)
                throw new ServiceErrorException(107);

            var user = await UserRepository
                .GetAll()
                .Where(x => x.Login.Equals(phone))
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(109);

            user.Password = CryptHelper.CreateMD5(request.NewPassword);

            UserRepository.Update(user);
            await UserRepository.SaveChangesAsync();
        }

        public async Task ChangePassword(ChangePasswordDTO request, User user)
        {
            var cryptPassword = CryptHelper.CreateMD5(request.OldPassword);

            if (cryptPassword != user.Password)
                throw new ServiceErrorException(114);

            if(request.ConfirmPassword != request.NewPassword)
                throw new ServiceErrorException(115);

            if (request.NewPassword.Length < 6)
                throw new ServiceErrorException(108);

            user.Password = request.ConfirmPassword;

            request.ConfirmPassword = CryptHelper.CreateMD5(request.ConfirmPassword);

            UserRepository.Update(user);
            await UserRepository.SaveChangesAsync();
        }
    }
}
