using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AfterBuyAdditionalServant : Entity
    {
        public AdditionalOptions AdditionalOptions { get; set; }
        public Servant Servant { get; set; }
    }
}
