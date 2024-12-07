using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DeletedManager : IDeletedServices
    {
        private readonly IRepositoryManager _manager;
        public DeletedManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Deleted CreateOneDeleted(Deleted deleted)
        {
            if (deleted == null)
            {
                throw new ArgumentNullException(nameof(deleted));
            }
            _manager.DeletedR.CreateOneDeleted(deleted);
            _manager.Save();
            return deleted;
        }

        public void DeleteOneDeleted(int id, bool trackChanges)
        {
            var entity = _manager.DeletedR.GetOneDeletedById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Deleted with id:{id} could not found");
            _manager.DeletedR.DeleteOneDeleted(entity);
            _manager.Save();
        }

        public IEnumerable<Deleted> GetAllDeleteds(bool trackChanges)
        {
            return _manager.DeletedR.GetAllDeleteds(trackChanges);
        }

        public Deleted GetOneDeletedById(int id, bool trackhanges)
        {
           return _manager.DeletedR.GetOneDeletedById(id, trackhanges);
        }

        public void UpdateOneDeleted(int id, Deleted deleted, bool trackChanges)
        {
            var entity = _manager.DeletedR.GetOneDeletedById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Deleted with id:{id} could not found");
            //check params
            if (deleted is null)
                throw new ArgumentNullException(nameof(deleted));
            entity.CarId = deleted.CarId;
            entity.DeleteTime = DateTime.Now;
            entity.AdminId= deleted.AdminId; 
            _manager.DeletedR.UpdateOneDeleted(entity);
            _manager.Save();
        }
    }
}
