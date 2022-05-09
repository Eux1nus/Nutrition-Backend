using Domain.Enum;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.SMSC;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Services.Code
{
    public class ActivationCodeService : IActivationCodeService
    {
        private readonly IActivationCodeRepository ActivationCodeRepository;
        private readonly ISmscService SmscService;
        private readonly IUserRepository UserRepository;

        public ActivationCodeService(IActivationCodeRepository activationCodeRepository, IUserRepository userRepository,
            ISmscService smscService)
        {
            ActivationCodeRepository = activationCodeRepository;
            UserRepository = userRepository;
            SmscService = smscService;
        }

        public async Task Check(string code, string phoneNumber, PhoneNumberType type)
        {
            var phone = PhoneHelper.Clear(phoneNumber);

            var activationCode = await ActivationCodeRepository
                .GetAll()
                .OrderByDescending(x => x.Id)
                .Where(x => (x.Code.Equals(code) || x.Code == "0000") // <--- поле с "0000" только для теста. Удалить при релизе
                && x.Number == phone
                && x.PhoneNumberType == type
                && !x.IsConfirmed)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(300);

            var elapsedTime = (DateTime.UtcNow - activationCode.Date).TotalSeconds;

            if (elapsedTime > 300)
                throw new ServiceErrorException(303);

            activationCode.IsConfirmed = true;

            ActivationCodeRepository.Update(activationCode);
            await ActivationCodeRepository.SaveChangesAsync();

        }

        public async Task Create(string phoneNumber, PhoneNumberType type)
        {
            var phone = PhoneHelper.Clear(phoneNumber);

            if (type == PhoneNumberType.ChangePassword)
            {
                var user = await UserRepository
                .GetAll()
                .Where(x => x.Login.Contains(phone))
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(106);
            }

            if (type == PhoneNumberType.Registration)
            {
                var oldUser = await UserRepository
                .GetAll()
                .Where(x => x.Login.Contains(phone))
                .FirstOrDefaultAsync();
                 if(oldUser!= null)  
                    throw new ServiceErrorException(101);
            }
            

            foreach (var oldCode in await ActivationCodeRepository.GetAll()
                .Where(x => x.Number.Contains(phone) && !x.IsConfirmed && x.PhoneNumberType == type)
                .ToListAsync())
            {
                oldCode.IsConfirmed = true;
                ActivationCodeRepository.Update(oldCode);
            }
            

            //var code =  SmscService.CreateCall(phone);
            var code = "0000";

            if (code != null)
            {
                var activCode = new ActivationCode
                {
                    Number = phone,
                    Date = DateTime.UtcNow,
                    Code = code,
                    IsConfirmed = false,
                    PhoneNumberType = type
                };

                ActivationCodeRepository.Create(activCode);
            }
            await ActivationCodeRepository.SaveChangesAsync();
        }
    }
}
