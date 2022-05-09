using DTO.Request;
using DTO.Response;
using Masters.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Authorize;
using Services.FoodDiary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Nutrition.Controllers
{
    public class FoodDiaryController : AuthorizeController
    {
        private readonly IFoodDiaryService FoodDiaryService;

        public FoodDiaryController(IHttpContextAccessor contextAccessor,
            IFoodDiaryService foodDiaryService, IAuthorizeService authorizeService)
            : base(authorizeService, contextAccessor)
        {
            FoodDiaryService = foodDiaryService;
        }

        /// <summary>
        /// Создать дневник
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(FoodDiaryDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateFoodDiary([FromBody] CreateFoodDiaryDTO request)
        {
            AuthorizeService.CheckUser(user);

            var response = await FoodDiaryService.CreateFoodDiary(request, user);

            return Ok(response);
        }


        /// <summary>
        /// Получить дневник по id
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(FoodDiaryDTO), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("application/json")]
        [HttpGet("id")]
        public async Task<IActionResult> GetFoodDiary(long? clientId)
        {
            return Ok(await FoodDiaryService.GetFoodDiary(clientId, user));
        }
    }
}
