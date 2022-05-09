using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class AdditionalOptionsRepository : Repository<AdditionalOptions>, IAdditionalOptionsRepository
    {
        public AdditionalOptionsRepository(AppDBContext context) : base(context)
        {

        }
    }
}
