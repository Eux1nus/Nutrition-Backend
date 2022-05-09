using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class EmailController : AuthorizeController
    {
        private readonly IEmailService EmailService;
        public EmailController(IHttpContextAccessor contextAccessor,
            IEmailService emailService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            EmailService = emailService;
        }

        /// <summary>
        /// Отправка сообщений
        /// </summary>
        /// <param name="sendMail"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("send-mail")]
        public async Task<IActionResult> SendMessage(string receiver, string subject, string text)
        {
            AuthorizeService.CheckUser(user);

            var response = await EmailService.SendMessage(receiver, subject, text);
            return Ok(response);
        }
    }
}
