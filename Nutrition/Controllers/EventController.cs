using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class EventController : AuthorizeController
    {
        private readonly ICalendarOfEventService CalendarOfEventService;

        public EventController(IHttpContextAccessor contextAccessor,
            ICalendarOfEventService calendarOfEventsService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            CalendarOfEventService = calendarOfEventsService;
        }

        /// <summary>
        /// Создать событие
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(EventDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create-event")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO request)
        {
            AuthorizeService.CheckUser(user);

            await CalendarOfEventService.CreateEvent(request);
            return Ok();
        }
    }
}
