using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class GearTypeRepository : RepositoryBase<GearType>, IGearTypeReppository
    {
        public GearTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<GearType> GetAllGearTypes(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id);

        public GearType GetGearTypeById(int id)
        {
            return _context.GearTypes.FirstOrDefault(ft => ft.Id == id);
        }

        public GearType GetOneGearTypeById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
