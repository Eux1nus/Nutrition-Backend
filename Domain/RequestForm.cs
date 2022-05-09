using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RequestForm : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long FoodDiaryId { get; set; }
        public FoodDiary FoodDiary { get; set; }

    }
}
