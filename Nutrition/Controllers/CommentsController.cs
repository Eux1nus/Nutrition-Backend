using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Controllers;
using Services.Authorize;
using Services.Comments;
using System.Threading.Tasks;
using Utils;

namespace Masters.Controllers
{
    public class CommentsController : AuthorizeController
    {
        private readonly ICommentsService CommentsService;

        public CommentsController(IHttpContextAccessor contextAccessor,
            ICommentsService commentsService, IAuthorizeService authorizeService) 
            : base(authorizeService, contextAccessor)
        {
            CommentsService = commentsService;
        }

        /// <summary>
        /// Создать комментарий
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CommentsDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentsDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await CommentsService.CreateComments(request, user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить коммент
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteComments(long commentsId)
        {
            AuthorizeService.CheckUser(user);
            await CommentsService.DeleteComments(commentsId, user);
            return Ok();
        }

        /// <summary>
        /// Получить список комментариев
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CommentsDTO[]), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<IActionResult> GetListComment(long reviewId)
        {
            AuthorizeService.CheckUser(user);

            var response = await CommentsService.GetComments(reviewId);
            return Ok(response);
        }
    }
}
