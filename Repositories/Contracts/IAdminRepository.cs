using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAdminRepository:IRepositoryBase<Admin>
    {
        IQueryable<Admin> GetAllAdmins(bool trackChanges);
        Admin GetAdminById(string id, bool trackChanges);
        void CreateOneAdmin(Admin admin);
        void UpdateOneAdmin(Admin admin);
        void DeleteOneAdmin(Admin admin);
    }
}
