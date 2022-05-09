using DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.Questions;
using Services.QuestionsPhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class QuestionsPhotoController : AuthorizeController
    {
        private readonly IQuestionsPhotoService QuestionsPhotoService;

        public QuestionsPhotoController

            (
            IHttpContextAccessor contextAccessor,
            IAuthorizeService authorizeService,
            IQuestionsPhotoService bloodTestPhotoService
            )

            : base(authorizeService, contextAccessor)
        {
            QuestionsPhotoService = bloodTestPhotoService;
        }

        /// <summary>
        /// Прикрепить файл
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CreateQuestionsPhotoDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create-questions-photo")]
        public async Task<IActionResult> CreateQuestionsPhoto([FromForm] CreateQuestionsPhotoDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await QuestionsPhotoService.CreateQuestionsPhoto(request, user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="questionsFileId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpDelete("delete-questions-photo")]
        public async Task<IActionResult> DeleteQuestionPhoto(long questionsFileId)
        {
            AuthorizeService.CheckUser(user);

            await QuestionsPhotoService.DeleteQuestionPhoto(questionsFileId, user);
            return Ok();
        }
    }
}
