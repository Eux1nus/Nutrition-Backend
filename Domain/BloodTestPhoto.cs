using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BloodTestPhoto : Entity 
    {
        public long FromUserId { get; set; }
        public User FromUser { get; set; }
        public string Photo { get; set; }

        public DateTime CreateDate { get; set; }

        public long QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
