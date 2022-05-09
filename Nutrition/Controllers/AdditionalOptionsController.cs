using Domain;
using DTO.Response;
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
    public class AdditionalOptionsController : AuthorizeController
    {
        private readonly IServantService ServantService;

        public AdditionalOptionsController(IHttpContextAccessor contextAccessor,
            IServantService servantService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            ServantService = servantService;
        }

        /// <summary>
        /// Купить доп материалы услугу
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("buy-addit")]

        public async Task<IActionResult> BuyAdditionalOptions(long additionalOptionsId)
        {
            AuthorizeService.CheckUser(user);

            await ServantService.BuyAdditionalOptions(user, additionalOptionsId);
            return Ok();
        }

        /// <summary>
        /// Показать мои доп.услуги
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("my-addit")]
        public async Task<IActionResult> ShowMyAdditionalOptions()
        {
            AuthorizeService.CheckUser(user);

            var response = await ServantService.ShowMyAdditionalOptions(user);
            return Ok(response);
        }

        /// <summary>
        /// Показать доп материалы после консультации услуги
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("get-afterbuy-addit")]
        public IActionResult ShowAfterBuyAdditionals(long servantId)
        {
            AuthorizeService.CheckUser(user);
            var listOfAdditionalOptions = ServantService.ShowAfterConsultationAdditionals(user, servantId);
            return Ok(listOfAdditionalOptions);
        }

        /// Показать доп материалы после покупки услуги
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("get-afterbuy-servants")]
        public IActionResult ShowAfterBuyServantsOptions(long servantId)
        {
            AuthorizeService.CheckUser(user);
            var listOfAfterBuyServants = ServantService.ShowAfterBuyServantsOptions(user, servantId);
            return Ok(listOfAfterBuyServants);
        }
    }
}
