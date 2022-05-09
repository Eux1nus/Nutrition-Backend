using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ActivationCodesRepository : Repository<ActivationCode>, IActivationCodeRepository
    {
        public ActivationCodesRepository(AppDBContext context) : base(context)
        {
        }
    }
}
