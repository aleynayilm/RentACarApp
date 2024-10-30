using RentACarApp.Api.Models;

namespace RentACarApp.Api.Repositories.Contracts
{
    public interface ICarRepository:IRepositoryBase<Car>
    {
        IQueryable<Car> GetAllCar(bool trackChanges);
        Car GetOneCarByVinNumber(string vinNumber, bool trackChanges);
        void CreateOneCar(Car car);
        void UpdateOneCar(Car car);
        void DeleteOneCar(Car car);
    }
}
