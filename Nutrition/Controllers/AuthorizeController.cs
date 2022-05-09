using Domain;
using Microsoft.AspNetCore.Http;
using Nutrition.Controllers;
using Services.Authorize;
using System.Threading.Tasks;

namespace Nutrition.Controllers
{
    public class AuthorizeController : BaseController
    {
        public readonly User user;
        public readonly IAuthorizeService AuthorizeService;
        public AuthorizeController(IAuthorizeService authorizeService, IHttpContextAccessor contextAccessor)
        {
            AuthorizeService = authorizeService;
            user = AuthorizeService.GetUser(contextAccessor).Result;
        }
    }
}
