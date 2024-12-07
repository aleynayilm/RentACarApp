using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class FuelTypeRepository : RepositoryBase<FuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<FuelType> GetAllFuelTypes(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id);

        public FuelType GetOneFuelTypeById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
