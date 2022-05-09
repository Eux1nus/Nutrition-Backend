using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Authorize
{
    public class AuthorizeService : IAuthorizeService
    {
        private IUserRepository UserRepository { get; set; }

        public AuthorizeService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<User> GetUser(IHttpContextAccessor contextAccessor)
        {
            return await UserRepository
                .GetAll()
                .Include(x => x.Person)
                .Where(x => x.Login == contextAccessor.HttpContext.User.Identity.Name)
                .FirstOrDefaultAsync();
        }

        public void CheckUser(User user)
        {
            if (user == null)
                throw new ServiceErrorException(106);
            if (user.IsActivated == false)
                throw new ServiceErrorException(104);
        }

        public void CheсkRights(User user)
        {
            if (user == null)
                throw new ServiceErrorException(106);
            if (user.IsActivated == false)
                throw new ServiceErrorException(104);
            if (user.UserRole == UserRole.Default)
                throw new ServiceErrorException(304);
        }
    }
}
