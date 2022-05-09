using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class QuestionnairePhotoDTO
    {
        public string Photo { get; set; }
        public long QuestionnaireId { get; set; }
        public UserDTO User { get; set; }

        public QuestionnairePhotoDTO() { }

        public QuestionnairePhotoDTO(BloodTestPhoto bloodTestPhoto)
        {
            if (bloodTestPhoto == null)
                return;

            Photo = bloodTestPhoto.Photo;
            QuestionnaireId = bloodTestPhoto.QuestionnaireId;
            User = new UserDTO(bloodTestPhoto.FromUser);
        }
    }
}
