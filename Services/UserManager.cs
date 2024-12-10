using AutoMapper;
using BCrypt.Net;
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
        private readonly ILoggerServices _logger;
        public UserManager(IRepositoryManager manager, IMapper mapper, ILoggerServices logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }
        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }
        public User CreateOneUser(UserDtoForCreate userDto)
        {
            if (userDto == null)
            {
                _logger.LogError("CreateOneUser: UserDto is null");
                throw new ArgumentNullException(nameof(userDto));
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            
            var user = _mapper.Map<User>(userDto);
            user.Password= hashedPassword;  // Hash'lenmiş şifreyi ekliyoruz
            _manager.UserR.CreateOneUser(user);
            _manager.Save();
            _logger.LogInfo($"CreateOneUser: User created successfully with ID: {user.Id}");
            return user;
        }

        public void DeleteOneUser(string id, bool trackChanges)
        {
            _logger.LogInfo($"DeleteOneUser: Attempting to delete user with ID: {id}");
            var entity = _manager.UserR.GetOneUserById(id, trackChanges);
            if (entity == null)
            {
                string message = $"DeleteOneUser: User with ID: {id} could not be found";
                _logger.LogError(message);
                throw new Exception(message);
            }
            _manager.UserR.DeleteOneUser(entity);
            _manager.Save();
            _logger.LogInfo($"DeleteOneUser: User with ID: {id} deleted successfully");
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            _logger.LogInfo("GetAllUsers: Retrieving all users");
            return _manager.UserR.GetAllUsers(trackChanges);
        }

        public User GetOneUserById(string id, bool trackChanges)
        {
            _logger.LogInfo($"GetOneUserById: Retrieving user with ID: {id}");
            var user = _manager.UserR.GetOneUserById(id, trackChanges);
            if (user == null)
            {
                string message = $"GetOneUserById: User with ID: {id} could not be found";
                _logger.LogWarning(message);
            }
            else
            {
                _logger.LogInfo($"GetOneUserById: User with ID: {id} retrieved successfully");
            }

            return user;
        }

        public void UpdateOneUser(string id, UserDtoForUpdate userDto, bool trackChanges)
        {
            _logger.LogInfo($"UpdateOneUser: Attempting to update user with ID: {id}");
            //check emtity
            var entity = _manager.UserR.GetOneUserById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The user with id:{id} could not found";
                _logger.LogError(message);
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
            _logger.LogInfo($"UpdateOneUser: User with ID: {id} updated successfully");
        }
    }
}
