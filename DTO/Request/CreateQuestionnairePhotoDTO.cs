using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateQuestionnairePhotoDTO
    {
        public IFormFile Photo { get; set; }
        public long QuestionnaireId { get; set; }
    }
}
