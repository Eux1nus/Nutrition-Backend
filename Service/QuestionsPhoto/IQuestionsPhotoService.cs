using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.QuestionsPhoto
{
    public interface IQuestionsPhotoService
    {
        Task<QuestionsPhotoDTO> CreateQuestionsPhoto(CreateQuestionsPhotoDTO request, User user);
        Task DeleteQuestionPhoto(long questionPhotoId, User user);
    }
}
