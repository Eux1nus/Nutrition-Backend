using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class AfterBuyAdditionalServantRepository : Repository<AfterBuyAdditionalServant>, IAfterBuyAdditionalServantRepository
    {
        public AfterBuyAdditionalServantRepository(AppDBContext context) : base(context)
        {

        }
    }
}
