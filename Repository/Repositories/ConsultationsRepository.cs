using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ConsultationsRepository : Repository<Consultations>, IConsultationsRepository
    {
        public ConsultationsRepository(AppDBContext context) : base(context)
        {

        }
    }
}
