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
    public class AdminManager : IAdminServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerServices _logger;
        public AdminManager(IRepositoryManager manager, IMapper mapper, ILoggerServices logger)
        {
            _manager= manager;
            _mapper = mapper;
            _logger= logger;
        }

        public Admin CreateOneAdmin(AdminDtoForCreate adminDto)
        {
            if (adminDto == null)
            {
                throw new ArgumentNullException(nameof(adminDto));
            }
            var admin = _mapper.Map<Admin>(adminDto);
            _manager.AdminR.CreateOneAdmin(admin);
            _manager.Save();
            _logger.LogInfo($"Admin with ID: {admin.Id} has been created successfully.");
            return admin;
        }

        public void DeleteOneAdmin(string id, bool trackChanges)
        {
            var entity = _manager.AdminR.GetAdminById(id, trackChanges);
            if (entity is null)
            {
                string message = $"Admin with ID: {id} could not be found.";
                _logger.LogWarning(message);
                throw new Exception(message);
            }
            _manager.AdminR.DeleteOneAdmin(entity);
            _manager.Save();
            _logger.LogInfo($"Admin with ID: {id} has been deleted successfully.");
        }

        public IEnumerable<Admin> GetAllAdmins(bool trackChanges)
        {
            return _manager.AdminR.GetAllAdmins(trackChanges);
        }

        public Admin GetOneAdminById(string id, bool trackChanges)
        {
            return _manager.AdminR.GetAdminById(id, trackChanges);
        }

        public void UpdateOneAdmin(string id, AdminDtoForUpdate adminDto, bool trackChanges)
        {
            var entity = _manager.AdminR.GetAdminById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The admin with id:{id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);

            }
            if (adminDto is null)
                throw new ArgumentNullException(nameof(adminDto));
            var existingCreatedAt = entity.CreatedAt;

            _mapper.Map(adminDto, entity);
            //entity = _mapper.Map<Admin>(adminDto);
            entity.CreatedAt = existingCreatedAt;
            _manager.AdminR.UpdateOneAdmin(entity);
            _manager.Save();
            _logger.LogInfo($"Admin with ID: {id} has been updated successfully.");
        }
    }
}
