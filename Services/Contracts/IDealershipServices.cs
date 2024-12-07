using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDealershipServices
    {
        IEnumerable<Dealership> GetAllDealerships(bool trackChanges);
        Dealership GetOneDealershipById(int id, bool trackChanges);
        Dealership CreateOneDealership(Dealership dealership);
        void UpdateOneDealership(int id, DealershipDtoForUpdate dealershipDto, bool trackChanges);
        void DeleteOneDealership(int id, bool trackChanges);
    }
}
