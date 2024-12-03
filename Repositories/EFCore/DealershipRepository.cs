using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class DealershipRepository : RepositoryBase<Dealership>, IDealershipRepository
    {
        public DealershipRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneDealership(Dealership dealership) => CreateOneDealership(dealership);

        public void DeleteOneDealership(Dealership dealership) => DeleteOneDealership(dealership);

        public IQueryable<Dealership> GetAllDealerships(bool trackChanges) => FindAll(trackChanges).OrderBy(c=>c.Id);

        public Dealership GetOneDealershipById(int id, bool trackChanges) => FindByCondiition(c=>c.Id.Equals(id),trackChanges).SingleOrDefault();

        public void UpdateOneDealership(Dealership dealership) => UpdateOneDealership(dealership);
    }
}
