using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class ConsultationDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }

        public ConsultationDTO() { }

        public ConsultationDTO(Consultations consultations)
        {
            if (consultations == null) 
                return;

            Id = consultations.Id;
            UserId = consultations.UserId;
            Description = consultations.Description;
            Name = consultations.Name;
            TimeStart = consultations.TimeStart;
        }
    }
}
