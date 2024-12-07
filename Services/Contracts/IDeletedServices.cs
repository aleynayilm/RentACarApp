using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDeletedServices
    {
        IEnumerable<Deleted> GetAllDeleteds(bool trackChanges);
        Deleted GetOneDeletedById(int id, bool trackhanges);
        Deleted CreateOneDeleted(Deleted deleted);
        void UpdateOneDeleted(int id, Deleted deleted, bool trackChanges);
        void DeleteOneDeleted(int id, bool trackChanges);
    }
}
