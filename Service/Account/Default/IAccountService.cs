using Domain;
using Domain.Enum;
using DTO.Request;
using DTO.Response;
using System.Threading.Tasks;

namespace Services.Account.Default
{
    public interface IAccountService 
    {
        Task<SignInDTO> Auth(AuthDTO request);

        Task<SignInDTO> Registration(CreatePersonDTO createPerson);

        Task SendCode(string phoneNumber, PhoneNumberType type);

        Task ActivationCode(string phoneNumber, string code, PhoneNumberType type);

        Task RestorePassword(CreateNewPasswordDTO request);

        Task ChangePassword(ChangePasswordDTO request, User user);

        Task<UserDTO> UpdateUser(CreatePersonDTO request, User user);
    }
}
