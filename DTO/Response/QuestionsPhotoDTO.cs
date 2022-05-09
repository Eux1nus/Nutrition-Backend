using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class QuestionsPhotoDTO
    {
        public string Photo { get; set; }
        public long QuestionsId { get; set; }
        public long UserId { get; set; }

        public QuestionsPhotoDTO() { }

        public QuestionsPhotoDTO(QuestionsPhoto questionsPhoto)
        {
            if (questionsPhoto == null)
                return;

            Photo = questionsPhoto.Photo;
            QuestionsId = questionsPhoto.QuestionsId;
            UserId = questionsPhoto.FromUser.Id;
        }
    }
}
