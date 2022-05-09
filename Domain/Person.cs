using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public SexType SexType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool AgreementIsChecked { get; set; }
    }
}
