using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDBContext context) : base(context)
        {

        }
    }
}
