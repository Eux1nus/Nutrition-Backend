using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.GifSertificate
{
    public interface IGiftSertificateService
    {
        Task<GiftSertificateDTO> GetGiftSertificate(CreateGiftSertificateDTO createInfo, User user, long giftSertificateId);
    }
}
