using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BloodTestPhotoRepository : Repository<BloodTestPhoto>, IBloodTestPhotoRepository
    {
        public BloodTestPhotoRepository(AppDBContext context) : base(context)
        {
        }
    }
}
