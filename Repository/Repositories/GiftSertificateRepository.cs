using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class GiftSertificateRepository : Repository<GiftSertificate>, IGiftSertificateRepository
    {
        public GiftSertificateRepository(AppDBContext context) : base(context)
        {

        }
    }
}
