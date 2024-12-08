using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Repositories.Contracts;
using Services.Contracts;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Services
{
    public class CarManager : ICarServices
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerServices _logger;
        private readonly IMapper _mapper;

        public CarManager(IRepositoryManager manager, ILoggerServices logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }
        public Car CreateOneCar(CarDtoForCreate carDto)
        {
            var fuelType = _manager.FuelTypeR.GetFuelTypeById(carDto.FuelType);
            if (fuelType == null)
            {
                throw new Exception($"FuelType '{carDto.FuelType}' not found!");
            }
            var gearType = _manager.GearTypeR.GetGearTypeById(carDto.GearType);
            if (gearType == null)
            {
                throw new Exception($"GearType '{carDto.GearType}' not found!");
            }
            var dealership = _manager.DealershipR.GetDealershipById(carDto.DealershipId);
            if (dealership == null)
            {
                throw new Exception($"Dealership '{carDto.DealershipId}' not found!");
            }

            var car = _mapper.Map<Car>(carDto);

            car.FuelType = fuelType.Id;
            car.GearType = gearType.Id;
            car.DealershipId = dealership.Id;
            try
            {
                _logger.LogInfo("Creating a new car in the database...");

                _manager.CarR.CreateOneCar(car);

                _logger.LogInfo("Saving changes to the database...");
                _manager.Save();

                _logger.LogInfo("Car created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create the car: {ex.Message}");
                if (ex.InnerException != null)
                {
                    _logger.LogError($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
            //_manager.CarR.CreateOneCar(carDto);
            //_manager.Save();
            return car;
        }

        public void DeleteOneCar(string vinNumber, bool trackChanges)
        {
            //check emtity
            var entity = _manager.CarR.GetOneCarByVinNumber(vinNumber, trackChanges);

            if (entity is null) {
                string message = $"The car with vin number:{vinNumber} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }

            _manager.CarR.DeleteOneCar(entity);
            _manager.Save();
        }

        public IEnumerable<Car> GetAllCars(bool trackChanges)
        {
            return _manager.CarR.GetAllCars(trackChanges);
        }

        public Car GetOneCarByVinNumber(string vinNumber, bool trackhanges)
            {
                return _manager.CarR.GetOneCarByVinNumber(vinNumber, trackhanges);
            }

            public void UpdateOneCar(string vinNumber, CarDtoForUpdate carDto, bool trackChanges)
        {
            //check emtity
            var entity = _manager.CarR.GetOneCarByVinNumber(vinNumber, trackChanges:true);
            if (entity is null)
            {
                string message = $"The car with vin number:{vinNumber} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);

            }
            var fuelType = _manager.FuelTypeR.GetOneFuelTypeById(carDto.FuelType, false);
            if (fuelType == null) throw new Exception("FuelType could not be found.");

            var gearType = _manager.GearTypeR.GetOneGearTypeById(carDto.GearType, false);
            if (gearType == null) throw new Exception("GearType could not be found.");

            var dealership = _manager.DealershipR.GetOneDealershipById(carDto.DealershipId, false);
            if (dealership == null) throw new Exception("Dealership could not be found.");
            entity.CreatedAt = _manager.CarR.GetOneCarByVinNumber(vinNumber, false).CreatedAt;

            var existingCreatedAt = entity.CreatedAt;

            _mapper.Map(carDto, entity);

            //entity = _mapper.Map<Car>(carDto);
            //entity.VinNumber = vinNumber;
            entity.FuelTypeNavigation = fuelType;
            entity.GearTypeNavigation = gearType;
            entity.Dealership = dealership;

            entity.CreatedAt = existingCreatedAt;

            try
            {
                _logger.LogInfo("Updating the car in the database...");
                _manager.CarR.UpdateOneCar(entity);

                _logger.LogInfo("Saving changes to the database...");
                _manager.Save();

                _logger.LogInfo("Car updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update the car: {ex.Message}, InnerException: {ex.InnerException?.Message}");
                throw;
            }

        }
    }
}
