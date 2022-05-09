using DTO.Request;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Events
{
    public class CalendarOfEventService : ICalendarOfEventService
    {
        public readonly ICalendarOfEventsRepository CalendarOfEventsRepository;

        public CalendarOfEventService(ICalendarOfEventsRepository calendarOfEventsRepository)
        {
            CalendarOfEventsRepository = calendarOfEventsRepository;
        }

        public async Task CreateEvent(CreateEventDTO request)
        {
            var events = new Domain.CalendarOfEvent

            {
                Type = request.Type,
                Description = request.Description,
                Duration = request.Duration,
                TimeStart = DateTime.UtcNow,
                TimeEnd = DateTime.UtcNow

            };

            await CalendarOfEventsRepository.CreateAsync(events);
            await CalendarOfEventsRepository.SaveChangesAsync();
        }
    }
}
