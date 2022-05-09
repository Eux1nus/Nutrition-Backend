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

namespace Services.BloodTestPhoto
{
    public class BloodTestPhotoService : IBloodTestPhotoService
    {
        private readonly IBloodTestPhotoRepository BloodTestPhotoRepository;
        private readonly IQuestionnaireRepository QuestionnaireRepository;
        private readonly IPhotoService PhotoService;
        public BloodTestPhotoService(IBloodTestPhotoRepository bloodTestPhotoRepository, IQuestionnaireRepository questionnaireRepository, IPhotoService photoService)
        {
            BloodTestPhotoRepository = bloodTestPhotoRepository;
            QuestionnaireRepository = questionnaireRepository;
            PhotoService = photoService;
        }

        public async Task<QuestionnairePhotoDTO> CreateQuestionnairePhoto(CreateQuestionnairePhotoDTO request, User user)
        {
            var photo = await PhotoService.AddPhoto(request.Photo);

            var questionnaire = await QuestionnaireRepository
                .GetAll()
                .Include(x => x.FromUser)
                .Where(x => x.Id == request.QuestionnaireId)
                .FirstOrDefaultAsync();

            var questionsPhoto = new Domain.BloodTestPhoto
            {
                FromUser = user,
                CreateDate = DateTime.Now,
                Questionnaire = questionnaire,
                Photo = photo
            };
                
            await BloodTestPhotoRepository.CreateAsync(questionsPhoto);
            await BloodTestPhotoRepository.SaveChangesAsync();

            return new QuestionnairePhotoDTO(questionsPhoto);
        }

        public async Task DeleteBloodTestPhoto(long bloodTestFileId, User user)
        {
            var bloodTestFile = await BloodTestPhotoRepository
                .GetAll()
                .Where(x => x.Id == bloodTestFileId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(113);

            if (bloodTestFile.FromUserId != user.Id)
                throw new ServiceErrorException(112);

            BloodTestPhotoRepository.Delete(bloodTestFile);
            await BloodTestPhotoRepository.SaveChangesAsync();
        }
    }

    
}
