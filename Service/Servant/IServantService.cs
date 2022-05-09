using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servants
{
    public interface IServantService
    {
        Task CreateServant(CreateServantDTO request);
        Task<ServantDTO[]> GetListServant();
        Task<ServantDTO[]> GetMyServants(User user);
        Task<ServantDTO> BuyServant(User user, long servantId);
        Task<UserAdditionalOptionsDTO> BuyAdditionalOptions(User user, long additionalOptionsId);
        Task<AdditionalOptionsDTO[]> ShowMyAdditionalOptions(User user);
        List<AdditionalOptionsDTO> ShowAfterConsultationAdditionals(User user, long servantId);
        List<AdditionalOptionsDTO> ShowAfterBuyServantsOptions(User user, long servantId);

    }
}
