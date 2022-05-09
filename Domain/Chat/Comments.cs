using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comments : Entity
    {
        public long FromUserId { get; set; }
        public User FromUser { get; set; }

        public DateTime CreateDate { get; set; }
        public string Description { get; set; }

        public long FoodDiaryId { get; set; }
        public FoodDiary FoodDiary { get; set; }
    }
}
