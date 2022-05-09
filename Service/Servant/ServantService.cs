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

namespace Services.Servants
{

    public class ServantService : IServantService
    {
        private readonly IServantRepository ServantRepository;
        private readonly IUserServantRepository UserServantRepository;
        private readonly IAdditionalOptionsRepository AdditionalOptionsRepository;
        private readonly IUserAdditionalOptionsRepository UserAdditionalOptionsRepository;
        private readonly IAfterBuyAdditionalServantRepository AfterBuyAdditionalRepository;
        private readonly IAdditionalOptionsServantRepository AdditionalOptionsServantRepository;
        public ServantService(IServantRepository servantRepository, 
                                IUserServantRepository userServantRepository, 
                                IAdditionalOptionsRepository additionalOptionsRepository,
                                IUserAdditionalOptionsRepository userAdditionalOptionsRepository,
                                IAfterBuyAdditionalServantRepository afterBuyAdditionalRepository,
                                IAdditionalOptionsServantRepository additionalOptionsServantRepository)
        {
            ServantRepository = servantRepository;
            UserServantRepository = userServantRepository;
            AdditionalOptionsRepository = additionalOptionsRepository;
            UserAdditionalOptionsRepository = userAdditionalOptionsRepository;
            AfterBuyAdditionalRepository = afterBuyAdditionalRepository;
            AdditionalOptionsServantRepository = additionalOptionsServantRepository;
        }

        public async Task CreateServant(CreateServantDTO request)
        {
            var servant = new Domain.Servant

            {
                ServantType = request.ServantType,
                Name = request.Name,
                Duration = request.Duration,
                TimeStart = DateTime.UtcNow,
                TimeEnd = DateTime.UtcNow

            };
            
            await ServantRepository.CreateAsync(servant);
            await ServantRepository.SaveChangesAsync();
        }

        public async Task<ServantDTO[]> GetListServant()
        {
            var getServant = await ServantRepository
                .GetAll()
                .AsNoTracking()
                .Select(x => new ServantDTO(x))
                .ToArrayAsync();

            return getServant;
        }

        public async Task<ServantDTO[]> GetMyServants(User user)
        {
            return await UserServantRepository
                .GetAll()
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .Select(x => new ServantDTO(x.Servant))
                .ToArrayAsync();
        }
            
        public async Task<ServantDTO> BuyServant(User user, long servantId)
        {
            var servant = await ServantRepository
                .GetAll()
                .Where(x=> x.Id == servantId)
                .FirstOrDefaultAsync()

                ?? throw new ServiceErrorException(116);

            var userServant = new UserServant
            {
                User = user,
                Servant = servant,
                DateCreate = DateTime.UtcNow,
                IsActivated = true
                
            };

            await UserServantRepository.CreateAsync(userServant);
            await UserServantRepository.SaveChangesAsync();

            return new ServantDTO(servant);
        }


        /// <summary>
        /// ПОлучить все доп услуги которые можно купить только после покупки указанной Услуги
        /// </summary>
        /// <param name="user"></param>
        /// <param name="servantId"></param>
        /// <returns></returns>
        public List<AdditionalOptionsDTO> ShowAfterConsultationAdditionals(User user, long servantId)
        {
            var userServant = UserServantRepository
                .GetAll()
                .FirstOrDefault(x => x.User.Id == user.Id && x.Servant.Id == servantId)
                ?? throw new ServiceErrorException(117);
            //Выдать ошибку что у пользователя нет купленной указанной услуги


            //Находим все записи в таблице AfterBuyAdditional в которых содержится указаннная услуга
            var afterBuyadditionals = AfterBuyAdditionalRepository
                .GetAll()
                .Where(x => x.Servant.Id == servantId);

            //Преобразуем найденный списиок в список необходимый сайту
            var listOfAdditionalOptions = afterBuyadditionals.Select(x => new AdditionalOptionsDTO(x.AdditionalOptions)).ToList();

            return listOfAdditionalOptions;
        }

        public List<AdditionalOptionsDTO> ShowAfterBuyServantsOptions(User user, long servantId)
        {
            var userServant = UserServantRepository
                .GetAll()
                .FirstOrDefault(x => x.User.Id == user.Id && x.Servant.Id == servantId)
                ?? throw new ServiceErrorException(117);


            var afterBuyServants = AdditionalOptionsServantRepository
                .GetAll()
                .Where(x => x.Servant.Id == servantId);

            var listOfAfterBuyServants = afterBuyServants.Select(x => new AdditionalOptionsDTO(x.AdditionalOptions)).ToList();

            return listOfAfterBuyServants;
        }

        public async Task<UserAdditionalOptionsDTO> BuyAdditionalOptions(User user, long additionalOptionsId)
        {
            var additional = await AdditionalOptionsRepository
                .GetAll()
                .Where(x => x.Id == additionalOptionsId)
                .FirstOrDefaultAsync()

                ?? throw new ServiceErrorException(117);

            var userAdditional = new UserAdditionalOptions
            {
                User = user,
                AdditionalOptions = additional
            };

            await UserAdditionalOptionsRepository.CreateAsync(userAdditional);
            await UserAdditionalOptionsRepository.SaveChangesAsync();

            return new UserAdditionalOptionsDTO(userAdditional);
        }

        public async Task<AdditionalOptionsDTO[]> ShowMyAdditionalOptions(User user)
        {
            return await UserAdditionalOptionsRepository
                .GetAll()
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .Select(x => new AdditionalOptionsDTO(x.AdditionalOptions))
                .ToArrayAsync()
            
                ?? throw new ServiceErrorException(118);
        }
    }
}
