using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ServantRepository : Repository<Servant>, IServantRepository
    {
        public ServantRepository(AppDBContext context) : base(context)
        {

        }
    }
}
