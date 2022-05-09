using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.GifSertificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class GiftSertificateController : AuthorizeController
    {
        private readonly IGiftSertificateService GiftSertificateService;

        public GiftSertificateController(IHttpContextAccessor contextAccessor,
            IGiftSertificateService giftSertificateService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            GiftSertificateService = giftSertificateService;
        }
        /// <summary>
        /// Получить серитификат
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ServantDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("get-gift")]

        public async Task<IActionResult> GetGiftSertificate(CreateGiftSertificateDTO createInfo, long giftSertificateId)
        {
            AuthorizeService.CheckUser(user);

            await GiftSertificateService.GetGiftSertificate(createInfo, user, giftSertificateId);
            return Ok();
        }
    }
}
