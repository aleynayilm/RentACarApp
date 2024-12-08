using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        IEnumerable<Admin> GetAllAdmins(bool trackChanges);
        Admin GetOneAdminById(string id, bool trackChanges);
        Admin CreateOneAdmin(AdminDtoForCreate adminDto);
        void UpdateOneAdmin(string id, AdminDtoForUpdate adminDto, bool trackChanges);
        void DeleteOneAdmin(string id, bool trackChanges);
    }
}
