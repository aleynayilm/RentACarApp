using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneAdmin(Admin admin) => Create(admin);

        public void DeleteOneAdmin(Admin admin)=> Delete(admin);

        public Admin GetAdminById(string id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public IQueryable<Admin> GetAllAdmins(bool trackChanges)=> FindAll(trackChanges).OrderBy(c=>c.Id);

        public void UpdateOneAdmin(Admin admin)=>Update(admin);
    }
}
