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
        User CreateOneUser(User user);
        void UpdateOneUser(string id, User user, bool trackChanges);
        void DeleteOneUser(string id, bool trackChanges);
    }
}
