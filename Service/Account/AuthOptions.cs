using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Services.Account
{
    public static class AuthOptions
    {
        public const string ISSUER = "nutrition-auth-server"; // издатель токена
        public const string AUDIENCE = "http://localhost:5000/"; // потребитель токена
        const string KEY = "jd645JHkdH348t2hjf3ujd4wk";   // ключ для шифрации
        public const int LIFETIME = 120000; // время жизни токена - 120 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}