using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateQuestionsDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public long UserId { get; set; }
    }
}
