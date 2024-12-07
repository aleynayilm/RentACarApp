using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFuelTypeServices
    {
        IEnumerable<FuelType> GetAllFuelTypes(bool trackChanges);
        FuelType GetOneFuelTypesById(int id, bool trackhanges);
    }
}
