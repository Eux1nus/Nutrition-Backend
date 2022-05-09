using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AppDBContext context) : base(context)
        {

        }
    }
}
