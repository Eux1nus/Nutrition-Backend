using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class UserServantRepository : Repository<UserServant>, IUserServantRepository
    {
        public UserServantRepository(AppDBContext context) : base (context)
        {
        }
    }
}
