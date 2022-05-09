using Domain;
using DTO.Request;
using DTO.Response;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Consultations
{
    public class ConsultationsService : IConsultationsService
    {
        private readonly IConsultationsRepository ConsultationsRepository;
        public ConsultationsService(IConsultationsRepository consultationsRepository)
        {
            ConsultationsRepository = consultationsRepository;
        }

        public async Task<ConsultationDTO> CreateConsultation(CreateConsultationDTO request, User user)
        {
            var consultations = new Domain.Consultations
            {
                Name = request.Name,
                Description = request.Description,
                TimeStart = DateTime.Now,
                UserId = user.Id
            };

            await ConsultationsRepository.CreateAsync(consultations);
            await ConsultationsRepository.SaveChangesAsync();

            return new ConsultationDTO(consultations);
        }
    }
}
