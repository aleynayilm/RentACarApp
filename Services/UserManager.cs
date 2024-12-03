using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserManager : IUserServices
    {
        private readonly IRepositoryManager _manager;
        public UserManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public User CreateOneUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _manager.UserR.CreateOneUser(user);
            _manager.Save();
            return user;
        }

        public void DeleteOneUser(string id, bool trackChanges)
        {
            var entity = _manager.UserR.GetOneUserById(id, trackChanges);
            if (entity is null)
                throw new Exception($"User with id:{id} could not found");
            _manager.UserR.DeleteOneUser(entity);
            _manager.Save();
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return _manager.UserR.GetAllUsers(trackChanges);
        }

        public User GetOneUserById(string id, bool trackChanges)
        {
            return _manager.UserR.GetOneUserById(id, trackChanges);
        }

        public void UpdateOneUser(string id, User user, bool trackChanges)
        {
            //check emtity
            var entity = _manager.UserR.GetOneUserById(id, trackChanges);
            if (entity is null)
                throw new Exception($"User with id:{id} could not found");
            //check params
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            entity.Name = user.Name;
            entity.Lastname = user.Lastname;
            entity.BirthDate = user.BirthDate;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.PhoneNumber = user.PhoneNumber;
            entity.LicenseNumber = user.LicenseNumber;
            entity.Address = user.Address;
            _manager.UserR.UpdateOneUser(entity);
            _manager.Save();
        }
    }
}
