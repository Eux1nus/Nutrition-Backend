using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public long PersonId { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActivated { get; set; }
        public long? SubscribeId { get; set; }
        public Person Person { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}
