using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public  class EventDTO
    {
        public long Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public EventDTO() { }

        public EventDTO(CalendarOfEvent events)
        {
            if (events == null)
                return;

            Id = events.Id;
            TimeStart = events.TimeStart;
            TimeEnd = events.TimeEnd;

        }
    }
}
