using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.FoodDiary
{
    public class FoodDiaryService : IFoodDiaryService
    {
        private readonly IFoodDiaryRepository FoodDiaryRepository;
        public FoodDiaryService(IFoodDiaryRepository foodDiaryRepository)
        {
            FoodDiaryRepository = foodDiaryRepository;
        }
        public async Task<FoodDiaryDTO> CreateFoodDiary(CreateFoodDiaryDTO request, User user)
        {
            var newFoodDiary = new Domain.FoodDiary
            {
                Breakfast = request.Breakfast,
                Lunch = request.Lunch,
                Brunch = request.Brunch,
                UserId = user.Id,
                TimeStart = DateTime.UtcNow
            };
            
            await FoodDiaryRepository.CreateAsync(newFoodDiary);
            await FoodDiaryRepository.SaveChangesAsync();

            return new FoodDiaryDTO(newFoodDiary);
        }

        public async Task<FoodDiaryDTO> GetFoodDiary(long? clientId, User user)
        {
            var id = clientId == null ? user.Id : clientId.Value;

            var getFoodDiary = await FoodDiaryRepository
                .GetAll()
                .Where(x => id == x.UserId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException();

            return new FoodDiaryDTO(getFoodDiary);
        }
    }
}
