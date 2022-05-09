using Domain;
using DTO.Request;
using DTO.Response;
using System.Threading.Tasks;

namespace Services.FoodDiary
{
    public interface IFoodDiaryService
    {
        Task<FoodDiaryDTO> CreateFoodDiary(CreateFoodDiaryDTO request, User user);

        Task<FoodDiaryDTO> GetFoodDiary(long? clientId, User user);
    }
}
