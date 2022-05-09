using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Questionnaire
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireDTO> CreateQuestionnaire(CreateQuestionnaireDTO request, User user);
        Task DeleteQuestionnaire(long questionnaireId, User user);
        Task<QuestionnaireDTO[]> GetQuestionnaire(long userId);
    }
}
