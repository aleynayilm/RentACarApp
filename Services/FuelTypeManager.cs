using AutoMapper;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FuelTypeManager : IFuelTypeServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public FuelTypeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IEnumerable<FuelType> GetAllFuelTypes(bool trackChanges)
        {
            return _manager.FuelTypeR.GetAllFuelTypes(trackChanges);
        }

        public FuelType GetOneFuelTypesById(int id, bool trackhanges)
        {
            return _manager.FuelTypeR.GetOneFuelTypeById(id, trackhanges);
        }
    }
}
