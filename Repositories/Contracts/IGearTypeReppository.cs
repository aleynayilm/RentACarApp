using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IGearTypeReppository:IRepositoryBase<GearType>
    {
        IQueryable<GearType> GetAllGearTypes(bool trackChanges);
        GearType GetOneGearTypeById(int id, bool trackChanges);
        GearType GetGearTypeById(int id);
    }
}
