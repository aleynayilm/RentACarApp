using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDealershipRepository :IRepositoryBase<Dealership>
    {
        IQueryable<Dealership> GetAllDealerships(bool trackChanges);
        Dealership GetOneDealershipById(int id, bool trackChanges);
        void CreateOneDealership(Dealership dealership);
        void UpdateOneDealership(Dealership dealership);
        void DeleteOneDealership(Dealership dealership);
        Dealership GetDealershipById(int id);
    }
}
