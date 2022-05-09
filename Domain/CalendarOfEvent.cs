using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CalendarOfEvent : Entity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
    }
}
