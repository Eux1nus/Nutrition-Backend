using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.SMSC
{
    public class SmscService : ISmscService
    {
        public SmscService()
        {
            
        }

        public async Task Send(string phoneNumber, string text)
        {

            var client = new HttpClient();
            string url = $"https://smsc.ru/sys/send.php?login=email&psw=password&phones={phoneNumber}&mes={text}";

            await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

        }


        public async Task SendMany(string[] phoneNumber, string text)
        {
            var client = new HttpClient();
            string url = $"https://smsc.ru/sys/send.php?login=email&psw=password&phones={phoneNumber}&mes={text}";

            await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

        }


        public string CreateCall(string phoneNumber)
        {
            string url = $"https://smsc.ru/sys/send.php?login=email&psw=password&phones={phoneNumber}&mes=code&call=1";

            var response = new WebClient().DownloadString(url);

            if (response.Contains("OK"))
            {
                var code = response.Substring(response.Length - 4);

                return code;
            }

            else
                throw new ServiceErrorException(880);
            
        }
    }
}
