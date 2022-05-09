using Domain;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services.Authorize
{
    public interface IAuthorizeService
    {
        void CheckUser(User user);
        void CheсkRights(User user);
        Task<User> GetUser(IHttpContextAccessor contextAccessor);
    }
}
