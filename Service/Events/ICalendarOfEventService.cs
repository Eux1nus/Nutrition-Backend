using DTO.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Events
{
    public interface ICalendarOfEventService
    {
        Task CreateEvent(CreateEventDTO request);
    }
}
