using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Controllers;
using Services.Authorize;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Consultations
{
    public class ConsultationsController : AuthorizeController
    {
        private readonly IConsultationsService ConsultationsService;

        public ConsultationsController(IHttpContextAccessor contextAccessor,
            IConsultationsService consultationsService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            ConsultationsService = consultationsService;
        }

        /// <summary>
        /// Создать консультацию
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ConsultationDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateConsultation([FromBody] CreateConsultationDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await ConsultationsService.CreateConsultation(request, user);
            return Ok(response);
        }
    }
}