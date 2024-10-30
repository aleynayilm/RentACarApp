using RentACarApp.Api.Models;

namespace RentACarApp.Api.Services.Contracts
{
    public interface ICarServices
    {
        IEnumerable<Car> GetAllCars(bool trackChanges);
        Car GetOneCarByVinNumber(string vinNumber, bool trackhanges);
        Car CreateOneCar(Car car);
        void UpdateOneCar(string vinNumber, Car car, bool trackChanges);
        void DeleteOneCar(string vinNumber, bool trackChanges);
    }
}
