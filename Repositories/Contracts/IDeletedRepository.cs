using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDeletedRepository
    {
        IQueryable<Deleted> GetAllDeleteds(bool trackChanges);
        Deleted GetOneDeletedById(int id, bool trackChanges);
        void CreateOneDeleted(Deleted deleted);
        void UpdateOneDeleted(Deleted deleted);
        void DeleteOneDeleted(Deleted deleted);
    }
}
