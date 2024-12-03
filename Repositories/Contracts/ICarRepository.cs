using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICarRepository:IRepositoryBase<Car>
    {
        IQueryable<Car> GetAllCars(bool trackChanges);
        Car GetOneCarByVinNumber(string vinNumber, bool trackChanges);
        void CreateOneCar(Car car);
        void UpdateOneCar(Car car);
        void DeleteOneCar(Car car);
    }
}
