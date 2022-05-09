using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Consultations : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

    }
}
