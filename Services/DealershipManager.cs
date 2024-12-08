using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class DealershipManager : IDealershipServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public DealershipManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public Dealership CreateOneDealership(DealershipDtoForCreate dealershipDto)
        {
            if (dealershipDto == null)
            {
                throw new ArgumentNullException(nameof(dealershipDto));
            }
            var dealership = _mapper.Map<Dealership>(dealershipDto);
            _manager.DealershipR.CreateOneDealership(dealership);
            _manager.Save();
            return dealership;
        }

        public void DeleteOneDealership(int id, bool trackChanges)
        {
            var entity = _manager.DealershipR.GetOneDealershipById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Dealership with id:{id} could not found");
            _manager.DealershipR.DeleteOneDealership(entity);
            _manager.Save();
        }

        public IEnumerable<Dealership> GetAllDealerships(bool trackChanges)
        {
           return _manager.DealershipR.GetAllDealerships(trackChanges);
        }

        public Dealership GetOneDealershipById(int id, bool trackChanges)
        {
            return _manager.DealershipR.GetOneDealershipById(id, trackChanges);
        }

        public void UpdateOneDealership(int id, DealershipDtoForUpdate dealershipDto, bool trackChanges)
        {
            var entity = _manager.DealershipR.GetOneDealershipById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The dealership with id:{id} could not found";
                //_logger.LogInfo(message);
                throw new Exception(message);

            }
            //check params
            if (dealershipDto is null)
                throw new ArgumentNullException(nameof(dealershipDto));
            _mapper.Map(dealershipDto, entity);
            //entity = _mapper.Map<Dealership>(dealershipDto);
            _manager.DealershipR.UpdateOneDealership(entity);
            _manager.Save();
        }
    }
}
