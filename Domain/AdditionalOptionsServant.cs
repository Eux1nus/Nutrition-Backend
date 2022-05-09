using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AdditionalOptionsServant : Entity
    {
        public AdditionalOptions AdditionalOptions { get; set; }
        public Servant Servant { get; set; }
    }
}
