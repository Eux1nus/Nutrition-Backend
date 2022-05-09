using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateQuestionsPhotoDTO
    {
        public IFormFile Photo { get; set; }

        public long QuestionsId { get; set; }
    }
}
