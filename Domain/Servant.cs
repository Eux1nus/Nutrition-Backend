using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Servant : Entity
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool IsActivated { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public ServantType ServantType { get; set; }
    }
}
