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
        public AdminManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager= manager;
            _mapper = mapper;
        }

        public Admin CreateOneAdmin(Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException(nameof(admin));
            }
            _manager.AdminR.CreateOneAdmin(admin);
            _manager.Save();
            return admin;
        }

        public void DeleteOneAdmin(string id, bool trackChanges)
        {
            var entity = _manager.AdminR.GetAdminById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Admin with id:{id} could not found");
            _manager.AdminR.DeleteOneAdmin(entity);
            _manager.Save();
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
                //_logger.LogInfo(message);
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
        }
    }
}
