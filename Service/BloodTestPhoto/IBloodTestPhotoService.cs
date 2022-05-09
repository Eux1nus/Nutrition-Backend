using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BloodTestPhoto
{
    public interface IBloodTestPhotoService
    {
        Task<QuestionnairePhotoDTO> CreateQuestionnairePhoto(CreateQuestionnairePhotoDTO request, User user);
        Task DeleteBloodTestPhoto(long bloodTestFileId, User user);
    }
}
