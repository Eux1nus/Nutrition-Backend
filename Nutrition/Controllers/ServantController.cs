using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.Servants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class ServantController : AuthorizeController
    {
        private readonly IServantService ServantService;

        public ServantController(IHttpContextAccessor contextAccessor,
            IServantService servantService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            ServantService = servantService;
        }
        /// <summary>
        /// Создать услугу
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateServant([FromBody] CreateServantDTO request)
        {
            AuthorizeService.CheckUser(user);

            await ServantService.CreateServant(request);
            return Ok();
        }

        /// <summary>
        /// Получить список услуг
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<IActionResult> GetListServant()
        {
            AuthorizeService.CheckUser(user);

            var response = await ServantService.GetListServant();
            return Ok(response);
        }

        /// <summary>
        /// Купить услугу
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("buy")]

        public async Task<IActionResult> BuyServant(long servantId)
        {
            AuthorizeService.CheckUser(user);

            await ServantService.BuyServant(user, servantId);
            return Ok();
        }

        /// <summary>
        /// Получить мои услуги
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("my-list")]
        public async Task<IActionResult> GetMyServants()
        {
            AuthorizeService.CheckUser(user);

            var response = await ServantService.GetMyServants(user);
            return Ok(response);
        }

    }
}
