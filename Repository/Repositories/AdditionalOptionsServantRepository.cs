using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class AdditionalOptionsServantRepository : Repository<AdditionalOptionsServant>, IAdditionalOptionsServantRepository
    {
        public AdditionalOptionsServantRepository(AppDBContext context) : base(context)
        {

        }
    }
}
