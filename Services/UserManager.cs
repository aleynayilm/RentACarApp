using AutoMapper;
using Entities.DataTransferObjects;
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
        private readonly IMapper _mapper;
        public UserManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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

        public void UpdateOneUser(string id, UserDtoForUpdate userDto, bool trackChanges)
        {
            //check emtity
            var entity = _manager.UserR.GetOneUserById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The user with id:{id} could not found";
                //_logger.LogInfo(message);
                throw new Exception(message);

            }
            //check params
            if (userDto is null)
                throw new ArgumentNullException(nameof(userDto));
            var existingCreatedAt = entity.CreatedAt;

            _mapper.Map(userDto, entity);
            //entity = _mapper.Map<User>(userDto);
            entity.CreatedAt = existingCreatedAt;
            _manager.UserR.UpdateOneUser(entity);
            _manager.Save();
        }
    }
}
