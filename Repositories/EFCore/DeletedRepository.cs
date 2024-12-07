using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class DeletedRepository : RepositoryBase<Deleted>, IDeletedRepository
    {
        public DeletedRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneDeleted(Deleted deleted) => CreateOneDeleted(deleted);

        public void DeleteOneDeleted(Deleted deleted)=> DeleteOneDeleted(deleted);

        public IQueryable<Deleted> GetAllDeleteds(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id);

        public Deleted GetOneDeletedById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneDeleted(Deleted deleted)=> UpdateOneDeleted(deleted);
    }
}
