using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateCommentsDTO
    {
        public string Description { get; set; } 
        public long FoodDiaryId { get; set; }
    }
}
