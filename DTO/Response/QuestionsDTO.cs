using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class QuestionsDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public QuestionsDTO() { }

        public QuestionsDTO(Questions questions)
        {
            if (questions == null)
                return;

            Id = questions.Id;
            UserId = questions.FromUserId;
            Description = questions.Description;
            Name = questions.FromUser.Person.Name;
            CreateDate = questions.CreateDate;
        }
    }
}
