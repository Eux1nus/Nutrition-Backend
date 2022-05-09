using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Payment : Entity
    {
        public User User { get; set; }
        public Servant Servant { get; set; } 
        public bool IsPayed { get; set; }
        public DateTime DateTime { get; set; }

    }
}
