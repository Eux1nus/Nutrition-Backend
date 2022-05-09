using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ServantPhotoRepository : Repository<ServantPhoto>, IServantPhotoRepository
    {
        public ServantPhotoRepository(AppDBContext context) : base(context)
        {

        }
    }
}
