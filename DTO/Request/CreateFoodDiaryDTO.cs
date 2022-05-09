using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateFoodDiaryDTO
    {
        public DateTime TimeStart { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Brunch { get; set; }
        public long UserId { get; set; }
    }
}
