using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace Services
{
    public class CarManager : ICarServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepositoryManager _manager;
        private readonly ILoggerServices _logger;
        private readonly IMapper _mapper;
        private readonly IDeletedServices _deletedManager;

        public CarManager(IHttpContextAccessor httpContextAccessor, IRepositoryManager manager, ILoggerServices logger, IMapper mapper, IDeletedServices deletedManager)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _deletedManager = deletedManager;
        }
        public Car CreateOneCar(CarDtoForCreate carDto)
        {
            _logger.LogInfo("Starting the process to create a new car.");
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
            return car;
        }
        public void DeleteOneCar([FromRoute(Name = "vinNumber")] string vinNumber, bool trackChanges)
        {
            _logger.LogInfo($"Starting the process to delete the car with VIN: {vinNumber}.");
            var entity = _manager.CarR.GetOneCarByVinNumber(vinNumber, trackChanges);

            if (entity is null) {
                string message = $"The car with vin number:{vinNumber} could not found";
                _logger.LogWarning(message);
                throw new Exception(message);
            }

            try
            {
                _manager.CarR.DeleteOneCar(entity);
                _logger.LogInfo("Deleting the car from the database.");

                _manager.Save();
                _logger.LogInfo($"Car with VIN: {vinNumber} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete the car: {ex.Message}");
                if (ex.InnerException != null)
                {
                    _logger.LogError($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        public IEnumerable<Car> GetAllCars(bool trackChanges)
        {
            _logger.LogInfo("Retrieving all cars from the database.");
            return _manager.CarR.GetAllCars(trackChanges);
        }

        public Car GetOneCarByVinNumber(string vinNumber, bool trackhanges)
            {
            _logger.LogInfo($"Retrieving the car with VIN: {vinNumber}.");
            return _manager.CarR.GetOneCarByVinNumber(vinNumber, trackhanges);
            }

            public void UpdateOneCar(string vinNumber, CarDtoForUpdate carDto, bool trackChanges)
        {
            _logger.LogInfo($"Starting the process to update the car with VIN: {vinNumber}.");
            //check emtity
            var entity = _manager.CarR.GetOneCarByVinNumber(vinNumber, trackChanges:true);
            if (entity is null)
            {
                string message = $"The car with vin number:{vinNumber} could not found";
                _logger.LogWarning(message);
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
