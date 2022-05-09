using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Questions
{
    public interface IQuestionsService
    {
        Task<QuestionsDTO> CreateQuestions(CreateQuestionsDTO request, User user);
        Task DeleteQuestions(long questionsId, User user);
        Task<QuestionsDTO[]> GetQuestions(long questionId);
    }
}
