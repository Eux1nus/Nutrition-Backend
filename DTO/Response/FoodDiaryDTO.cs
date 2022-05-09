using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class FoodDiaryDTO
    {
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Brunch { get; set; }
        public long UserId { get; set; }
        public DateTime TimeStart { get; set; }

        public FoodDiaryDTO() { }
        public FoodDiaryDTO(FoodDiary foodDiary)
        {
            if (foodDiary == null)
                return;

            Breakfast = foodDiary.Breakfast;
            Lunch = foodDiary.Lunch;
            Brunch = foodDiary.Brunch;
            UserId = foodDiary.UserId;
            TimeStart = foodDiary.TimeStart;
        }
    }
}
