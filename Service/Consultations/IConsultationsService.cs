using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Consultations
{
    public interface IConsultationsService
    {
        Task<ConsultationDTO> CreateConsultation(CreateConsultationDTO request, User user);
    }
}
