using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDBContext context) : base (context)
        {

        }
    }
}
