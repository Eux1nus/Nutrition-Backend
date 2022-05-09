using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using Services.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.QuestionsPhoto
{
    public class QuestionsPhotoService : IQuestionsPhotoService
    {
        private readonly IQuestionsPhotoRepository QuestionsPhotoRepository;
        private readonly IQuestionsRepository QuestionsRepository;
        private readonly IPhotoService PhotoService;
        public QuestionsPhotoService(IQuestionsPhotoRepository questionsPhotoRepository, IQuestionsRepository questionsRepository, IPhotoService photoService)
        {
            QuestionsPhotoRepository = questionsPhotoRepository;
            QuestionsRepository = questionsRepository;
            PhotoService = photoService;
        }

        public async Task<QuestionsPhotoDTO> CreateQuestionsPhoto(CreateQuestionsPhotoDTO request, User user)
        {
            var photo = await PhotoService.AddPhoto(request.Photo);
            var questions = await QuestionsRepository
                .GetAll()
                .Include(x => x.FromUser)
                .Where(x => x.Id == request.QuestionsId)
                .FirstOrDefaultAsync()

                ?? throw new ServiceErrorException();

            var questionsPhoto = new Domain.QuestionsPhoto
            {
                FromUserId = user.Id,
                CreateDate = DateTime.Now,
                Questions = questions,
                Photo = photo
            };

            await QuestionsPhotoRepository.CreateAsync(questionsPhoto);
            await QuestionsPhotoRepository.SaveChangesAsync();

            return new QuestionsPhotoDTO(questionsPhoto);
        }

        public async Task DeleteQuestionPhoto(long questionsPhotoId, User user)
        {
            var questionsPhoto = await QuestionsPhotoRepository
                .GetAll()
                .Where(x => x.Id == questionsPhotoId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(113);

            if (questionsPhoto.FromUserId != user.Id)
                throw new ServiceErrorException(112);

            QuestionsPhotoRepository.Delete(questionsPhoto);
            await QuestionsPhotoRepository.SaveChangesAsync();
        }
    }
}
