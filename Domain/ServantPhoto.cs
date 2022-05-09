using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ServantPhoto : Entity
    {
        public string Photo { get; set; }
        public long ServantId { get; set; }
        public Servant Servant { get; set; }
    }
}
