using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ApplicationFormsRepository : Repository<RequestForm>, IApplicationFormsRepository
    {
        public ApplicationFormsRepository(AppDBContext context) : base(context)
        {
        }
    }
}
