using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Account.Default;
using Services.Authorize;
using Services.Servants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class UserProfileController : AuthorizeController
    {
        private readonly IAccountService AccountService;

        public UserProfileController(IHttpContextAccessor contextAccessor,
            IAccountService accountService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            AccountService = accountService;
        }
        /// <summary>
        ///  Обновить личные данные
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateUser([FromBody] CreatePersonDTO request)
        {
            await AccountService.UpdateUser(request, user);
            return Ok();
        }

        /// <summary>
        /// Изменить пароль / Change password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO request)
        {
            await AccountService.ChangePassword(request, user);
            return Ok();
        }
    }
}
