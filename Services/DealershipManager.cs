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
        public DealershipManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Dealership CreateOneDealership(Dealership dealership)
        {
            if (dealership == null)
            {
                throw new ArgumentNullException(nameof(dealership));
            }
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

        public void UpdateOneDealership(int id, Dealership dealership, bool trackChanges)
        {
            var entity = _manager.DealershipR.GetOneDealershipById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Dealership with id:{id} could not found");
            //check params
            if (dealership is null)
                throw new ArgumentNullException(nameof(dealership));
            entity.Name=dealership.Name;
            entity.Address=dealership.Address;
            entity.Phone=dealership.Phone;
            _manager.DealershipR.UpdateOneDealership(entity);
            _manager.Save();
        }
    }
}
