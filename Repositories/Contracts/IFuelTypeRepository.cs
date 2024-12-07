using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IFuelTypeRepository:IRepositoryBase<FuelType>
    {
        IQueryable<FuelType> GetAllFuelTypes(bool trackChanges);
        FuelType GetOneFuelTypeById(int id, bool trackChanges);
    }
}
