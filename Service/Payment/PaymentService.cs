using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Payment
{
    public class PaymentService : IPaymentService
    {
        public readonly IPaymentRepository PaymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }


    }
}
