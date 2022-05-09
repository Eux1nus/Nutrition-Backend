using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserAdditionalOptions : Entity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long AdditionalOptionsId { get; set; }
        public AdditionalOptions AdditionalOptions { get; set; }
    }
}