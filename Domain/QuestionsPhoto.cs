using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class QuestionsPhoto : Entity
    {
        public long FromUserId { get; set; }
        public User FromUser { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate { get; set; }

        public long QuestionsId { get; set; }
        public Questions Questions { get; set; }
    }
}
