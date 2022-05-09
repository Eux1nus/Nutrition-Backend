using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class CalendarOfEventsRepository : Repository<CalendarOfEvent>, ICalendarOfEventsRepository
    {
        public CalendarOfEventsRepository(AppDBContext context) : base(context) 
        {
        }
    }
}
