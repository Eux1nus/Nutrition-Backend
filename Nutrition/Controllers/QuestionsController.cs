using DTO.Request;
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
    public class QuestionsController : AuthorizeController
    {
        private readonly IQuestionsService QuestionsService;

        public QuestionsController(IHttpContextAccessor contextAccessor,
            IQuestionsService questionsService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            QuestionsService = questionsService;
        }

        /// <summary>
        /// Создать вопрос
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(QuestionsDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestions([FromBody] CreateQuestionsDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await QuestionsService.CreateQuestions(request, user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить вопрос
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteQuestions(long questionsId)
        {
            AuthorizeService.CheckUser(user);
            await QuestionsService.DeleteQuestions(questionsId, user);
            return Ok();
        }

        /// <summary>
        /// Получить список вопросов
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(QuestionsDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<IActionResult> GetListQuestions(long userId)
        {
            AuthorizeService.CheckUser(user);

            var response = await QuestionsService.GetQuestions(userId);
            return Ok(response);
        }
    }
}
