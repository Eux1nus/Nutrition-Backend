using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public  class CreateEventDTO
    {
        public EventType Type { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
