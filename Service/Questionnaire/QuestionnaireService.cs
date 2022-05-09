using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Questionnaire
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private IQuestionnaireRepository QuestionnaireRepository;

        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository)

        {
            QuestionnaireRepository = questionnaireRepository;
        }

        public async Task<QuestionnaireDTO> CreateQuestionnaire(CreateQuestionnaireDTO request, User user)
        {
            var questionnaire = new Domain.Questionnaire
            {
                FromUserId = user.Id,
                Heigh = request.Heigh,
                CurrentWeight = request.CurrentWeight,
                DesiredWeight = request.DesiredWeight,
                NeckVolume = request.NeckVolume,
                BreastVolume = request.BreastVolume,
                Hips = request.Hips,
                CreateDate = DateTime.Now,
                AboutMeInfo = request.AboutMeInfo,
                AlcoholDrink = request.AlcoholDrink,
                CoffeeDependence = request.CoffeeDependence,
                EndOfTheDayEnergy = request.EndOfTheDayEnergy,
                Pressure = request.Pressure,
                RegularStool = request.RegularStool,
                SleepTime = request.SleepTime,
                Smoking = request.Smoking,
                SupplySystem = request.SupplySystem,
                
                DailyDiet = request.DailyDiet,
                ChronicDiseases = request.ChronicDiseases,
                Allergies = request.Allergies,
                SportActivities = request.SportActivities,
                DietarySupplements = request.DietarySupplements,
                Diabetes = request.Diabetes,      
                SkinManifestations = request.SkinManifestations,
                MealsPerDay = request.MealsPerDay,
                ConsultationPurpose = request.ConsultationPurpose,
                TonguePlaque = request.TonguePlaque
                

            };

            await QuestionnaireRepository.CreateAsync(questionnaire);
            await QuestionnaireRepository.SaveChangesAsync();

            return new QuestionnaireDTO(questionnaire);
        }

        public async Task DeleteQuestionnaire(long questionnaireId, User user)
        {
            var questionnaire = await QuestionnaireRepository
                .GetAll()
                .Where(x => x.Id == questionnaireId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(113);

            if (questionnaire.FromUserId != user.Id)
                throw new ServiceErrorException(112);

            QuestionnaireRepository.Delete(questionnaire);
            await QuestionnaireRepository.SaveChangesAsync();
        }

        public async Task<QuestionnaireDTO[]> GetQuestionnaire(long userId)
        {
            var questionnaire = await QuestionnaireRepository
                .GetAll()
                .AsNoTracking()
                .Include(x => x.FromUser)
                .ThenInclude(x => x.Person)
                .Where(x => x.FromUserId == userId)
                .OrderBy(x => x.CreateDate)
                .Select(x => new QuestionnaireDTO(x))
                .ToArrayAsync();

            return questionnaire;
        }
    }
}
