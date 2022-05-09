using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AdditionalOptions : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
    }
}
