﻿using Entities.Models;
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

        public void CreateOneDealership(Dealership dealership) => Create(dealership);

        public void DeleteOneDealership(Dealership dealership) => Delete(dealership);

        public IQueryable<Dealership> GetAllDealerships(bool trackChanges) => FindAll(trackChanges).OrderBy(c=>c.Id);

        public Dealership GetDealershipById(int id)
        {
            return _context.Dealerships.FirstOrDefault(ft => ft.Id == id);
        }

        public Dealership GetOneDealershipById(int id, bool trackChanges) => FindByCondiition(c=>c.Id.Equals(id),trackChanges).SingleOrDefault();

        public void UpdateOneDealership(Dealership dealership) => Update(dealership);
    }
}
