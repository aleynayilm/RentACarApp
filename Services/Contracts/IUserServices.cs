using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserServices
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetOneUserById(string id, bool trackChanges);
        User CreateOneUser(UserDtoForCreate userDto);
        void UpdateOneUser(string id, UserDtoForUpdate userDto, bool trackChanges);
        void DeleteOneUser(string id, bool trackChanges);
    }
}
