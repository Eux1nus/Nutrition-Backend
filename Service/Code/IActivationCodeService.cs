using Domain.Enum;
using System.Threading.Tasks;

namespace Services.Code
{
    public interface IActivationCodeService
    {
        Task Check(string code, string phoneNumber, PhoneNumberType type);
        Task Create(string phoneNumber, PhoneNumberType type);
    }
}
