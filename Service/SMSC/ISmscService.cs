using System.Threading.Tasks;

namespace Services.SMSC
{
    public interface ISmscService
    {
       Task Send(string phoneNumber, string text);
       Task SendMany(string[] phoneNumber, string text);
       string CreateCall(string phoneNumber);
    }
}
