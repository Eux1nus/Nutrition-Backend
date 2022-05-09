using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GifSertificate
{
    public class GiftSertificateService : IGiftSertificateService
    {
        public readonly IGiftSertificateRepository GiftSertificateRepository;
        public readonly IUserGiftSertificateRepository UserGiftSertificateRepository;
        public GiftSertificateService(IGiftSertificateRepository giftSertificateRepository, IUserGiftSertificateRepository userGiftSertificateRepository)
        {
            GiftSertificateRepository = giftSertificateRepository;
            UserGiftSertificateRepository = userGiftSertificateRepository;
        }

        public async Task<GiftSertificateDTO> GetGiftSertificate(CreateGiftSertificateDTO createInfo, User user, long giftSertificateId)
        {
            var giftSertificate = await GiftSertificateRepository
                .GetAll()
                .Where(x => x.Id == giftSertificateId)
                .FirstOrDefaultAsync()

                ?? throw new ServiceErrorException(116);

            var userGiftSertificate = new UserGiftSertificate
            {
                User = user,
                GiftSertificate = giftSertificate,

                Name = createInfo.Name,
                LastName = createInfo.LastName,
                SurName = createInfo.SurName,
                Email = createInfo.Email,
                PhoneNumber = createInfo.PhoneNumber
            };

            
            await UserGiftSertificateRepository.CreateAsync(userGiftSertificate);
            await UserGiftSertificateRepository.SaveChangesAsync();

            return new GiftSertificateDTO(giftSertificate);
        }
    }
}
