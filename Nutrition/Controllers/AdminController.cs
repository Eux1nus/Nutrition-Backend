using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class AdminController : AuthorizeController
    {
        private readonly IQuestionsService QuestionsService;
        public AdminController(IHttpContextAccessor contextAccessor,
            IQuestionsService questionsService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            QuestionsService = questionsService;
        }

        /// <summary>
        /// Получить список вопросов
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(QuestionsDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("get-admin-questions")]
        public async Task<IActionResult> GetListQuestions(long userId)
        {
            AuthorizeService.CheсkRights(user);

            var response = await QuestionsService.GetQuestions(userId);
            return Ok(response);
        }
    }
}
