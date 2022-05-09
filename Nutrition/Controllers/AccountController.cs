using Domain;
using Domain.Enum;
using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Nutrition.Controllers;
using Services.Account.Default;
using System;
using System.Net;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService AccountService;

        public AccountController([FromServices]IAccountService accountService)
            
        {
            AccountService = accountService;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SignInDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] AuthDTO request)
        {
            var response = await AccountService.Auth(request);
            return Ok(response);
        }


        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SignInDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]CreatePersonDTO request)
        {
            var response = await AccountService.Registration(request);
            return Ok(response);
        }


        /// <summary>
        /// Отправить код
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("send-code")]
        public async Task<IActionResult> SendCode(string phoneNumber, PhoneNumberType type)
        {
            await AccountService.SendCode(phoneNumber, type);
            return Ok();
        }


        /// <summary>
        /// Активировать код
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("activation-code")]
        public async Task<IActionResult> ActivationCode(string phoneNumber, string code, PhoneNumberType type)
        {
            await AccountService.ActivationCode(phoneNumber, code, type);

            return Ok();
        }

        /// <summary>
        /// Востановить пароль / Restore password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("restore-password")]
        public async Task<IActionResult> RestorePassword([FromBody] CreateNewPasswordDTO request)
        {
            await AccountService.RestorePassword(request);
            return Ok();
        }
    }
}
