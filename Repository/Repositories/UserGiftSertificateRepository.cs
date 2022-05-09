using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class UserGiftSertificateRepository : Repository<UserGiftSertificate>, IUserGiftSertificateRepository 
    {
        public UserGiftSertificateRepository(AppDBContext context) : base(context)
        {

        }
    }
}
