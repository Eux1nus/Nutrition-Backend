using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ActivationCode : Entity
    {
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActivate { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }

        public bool IsConfirmed { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public void UpdateCode()
        {
            var rnd = new Random();
            var randomNumber = rnd.Next(100000, 999999).ToString();
            Code = randomNumber;
            Code = "000000";
        }
    }
}
