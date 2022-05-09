using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FoodDiary : Entity
    {
        public DateTime TimeStart { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Brunch { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
