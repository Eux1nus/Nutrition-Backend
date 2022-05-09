using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Questions
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository QuestionsRepository;
        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            QuestionsRepository = questionsRepository;
        }

        public async Task<QuestionsDTO> CreateQuestions(CreateQuestionsDTO request, User user)
        {
            var questions = new Domain.Questions
            {
                FromUserId = user.Id,
                Description = request.Description,
                CreateDate = DateTime.Now,
                ToUserId = request.UserId
            };
            if (questions.ToUserId != request.UserId)
                throw new ServiceErrorException(999);

            await QuestionsRepository.CreateAsync(questions);
            await QuestionsRepository.SaveChangesAsync();

            return new QuestionsDTO(questions);
        }

        public async Task DeleteQuestions(long questionsId, User user)
        {
            var questions = await QuestionsRepository
                .GetAll()
                .Where(x => x.Id == questionsId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(113);

            if (questions.FromUserId != user.Id)
                throw new ServiceErrorException(112);

            QuestionsRepository.Delete(questions);
            await QuestionsRepository.SaveChangesAsync();
        }

        public async Task<QuestionsDTO[]> GetQuestions(long userId)
        {
            var questions = await QuestionsRepository
                .GetAll()
                .AsNoTracking()
                .Include(x => x.FromUser)
                .ThenInclude(x => x.Person)
                .Where(x => x.FromUserId == userId)
                .OrderBy(x => x.CreateDate)
                .Select(x => new QuestionsDTO(x))
                .ToArrayAsync();

            return questions;
        }
    }
}
