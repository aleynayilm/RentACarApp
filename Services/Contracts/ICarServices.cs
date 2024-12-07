using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICarServices
    {
        IEnumerable<Car> GetAllCars(bool trackChanges);
        Car GetOneCarByVinNumber(string vinNumber, bool trackhanges);
        Car CreateOneCar(CarDtoForCreate carDto);
        void UpdateOneCar(string vinNumber, CarDtoForUpdate carDto, bool trackChanges);
        void DeleteOneCar(string vinNumber, bool trackChanges);
    }
}
