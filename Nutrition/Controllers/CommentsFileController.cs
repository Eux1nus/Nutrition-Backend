using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.Comments;
using Services.CommentsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class CommentsFileController : AuthorizeController
    {
        private readonly ICommentsFileService CommentsFileService;

        public CommentsFileController(IHttpContextAccessor contextAccessor,
            ICommentsFileService commentsFileService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            CommentsFileService = commentsFileService;
        }

        /// <summary>
        /// Прикрепить файл
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CommentsFileDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCommentFile([FromForm] CreateCommentsFileDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await CommentsFileService.CreateCommentsFile(request, user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="commentFileId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCommentsFile(long commentsFileId)
        {
            AuthorizeService.CheckUser(user);

            await CommentsFileService.DeleteComments(commentsFileId, user);
            return Ok();
        }
    }
}
