using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System.Diagnostics.Eventing.Reader;

namespace Services
{
    public class CarManager : ICarServices
    {
        private readonly IRepositoryManager _manager;

        public CarManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Car CreateOneCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            _manager.CarR.CreateOneCar(car);
            _manager.Save();
            return car;
        }

        public void DeleteOneCar(string vinNumber, bool trackChanges)
        {
            //check emtity
            var entity = _manager.CarR.GetOneCarByVinNumber(vinNumber, trackChanges);
            if (entity is null)
                throw new Exception($"Book with vin number:{vinNumber} could not found");
            _manager.CarR.DeleteOneCar(entity);
            _manager.Save();
        }

        public IEnumerable<Car> GetAllCars(bool trackChanges)
        {
            return _manager.CarR.GetAllCar(trackChanges);
        }

        public Car GetOneCarByVinNumber(string vinNumber, bool trackhanges)
        {
            return _manager.CarR.GetOneCarByVinNumber(vinNumber, trackhanges);
        }

        public void UpdateOneCar(string vinNumber, Car car, bool trackChanges)
        {
            //check emtity
            var entity = _manager.CarR.GetOneCarByVinNumber(vinNumber, trackChanges);
            if (entity is null)
                throw new Exception($"Book with vin number:{vinNumber} could not found");
            //check params
            if (car is null)
                throw new ArgumentNullException(nameof(car));
            entity.Brand = car.Brand;
            entity.Model = car.Model;
            entity.Year = car.Year;
            entity.FuelType = car.FuelType;
            entity.GearType = car.GearType;
            entity.LicensePlate = car.LicensePlate;
            entity.SeatCount = car.SeatCount;
            entity.PricePerDay = car.PricePerDay;
            entity.AvailabilityStatus = car.AvailabilityStatus;
            entity.CreatedAt = car.CreatedAt;
            entity.UpdatedAt = car.UpdatedAt;
            entity.MinAge = car.MinAge;
            entity.Kilometer = car.Kilometer;
            entity.Dealership = car.Dealership;
            _manager.CarR.UpdateOneCar(entity);
            _manager.Save();

        }
    }
}
