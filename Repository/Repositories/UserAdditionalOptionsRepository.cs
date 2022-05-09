using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class UserAdditionalOptionsRepository : Repository<UserAdditionalOptions>, IUserAdditionalOptionsRepository
    {
        public UserAdditionalOptionsRepository(AppDBContext context) : base(context)
        {

        }
    }
}
