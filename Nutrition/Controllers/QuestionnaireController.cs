using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.BloodTestPhoto;
using Services.Questionnaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class QuestionnaireController : AuthorizeController
    {
        private readonly IQuestionnaireService QuestionnaireService;
        private readonly IBloodTestPhotoService BloodTestPhotoService;

        public QuestionnaireController

            (
            IHttpContextAccessor contextAccessor,
            IQuestionnaireService questionnaireService, 
            IAuthorizeService authorizeService, 
            IBloodTestPhotoService bloodTestPhotoService
            )

            : base (authorizeService, contextAccessor)
        {
            QuestionnaireService = questionnaireService;
            BloodTestPhotoService = bloodTestPhotoService;
        }

        /// <summary>
        /// Создать анкету
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(QuestionnaireDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestionnaire([FromBody] CreateQuestionnaireDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await QuestionnaireService.CreateQuestionnaire(request, user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить анкету
        /// </summary>
        /// <param name="questionnaireId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteQuestionnaire(long questionnaireId)
        {
            AuthorizeService.CheckUser(user);
            await QuestionnaireService.DeleteQuestionnaire(questionnaireId, user);
            return Ok();
        }

        /// <summary>
        /// Получить анкету
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CommentsDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<IActionResult> GetQuestionnaire(long reviewId)
        {
            AuthorizeService.CheckUser(user);

            var response = await QuestionnaireService.GetQuestionnaire(reviewId);
            return Ok(response);
        }

        /// <summary>
        /// Прикрепить файл
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CreateQuestionnairePhotoDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create-questionnaire-photo")]
        public async Task<IActionResult> CreateQuestionnairePhoto([FromForm] CreateQuestionnairePhotoDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await BloodTestPhotoService.CreateQuestionnairePhoto(request, user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="bloodTestFileId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpDelete("delete-questionnaire-photo")]
        public async Task<IActionResult> DeleteBloodTestPhoto(long bloodTestFileId)
        {
            AuthorizeService.CheckUser(user);

            await BloodTestPhotoService.DeleteBloodTestPhoto(bloodTestFileId, user);
            return Ok();
        }
    }
}
