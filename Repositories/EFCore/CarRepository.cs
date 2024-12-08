using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;

namespace Repositories.EFCore
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCar(Car car) => Create(car);
        public void DeleteOneCar(Car car) => Delete(car);

        public IQueryable<Car> GetAllCars(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.VinNumber);

        public Car GetCar(string vinNumber)
        {
            return _context.Cars.FirstOrDefault(ft => ft.VinNumber == vinNumber);
        }

        public Car GetOneCarByVinNumber(string vinNumber, bool trackChanges) => FindByCondiition(c => c.VinNumber.Equals(vinNumber), trackChanges).SingleOrDefault();

        public void UpdateOneCar(Car car) => Update(car);
    }
}
