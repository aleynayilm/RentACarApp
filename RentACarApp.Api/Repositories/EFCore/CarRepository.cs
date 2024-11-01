﻿using RentACarApp.Api.Models;
using RentACarApp.Api.Repositories.Contracts;

namespace RentACarApp.Api.Repositories.EFCore
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCar(Car car) => CreateOneCar(car);
        public void DeleteOneCar(Car car) => DeleteOneCar(car);

        public IQueryable<Car> GetAllCar(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.VinNumber);

        public Car GetOneCarByVinNumber(string vinNumber, bool trackChanges) => FindByCondiition(c => c.VinNumber.Equals(vinNumber), trackChanges).SingleOrDefault();

        public void UpdateOneCar(Car car) =>UpdateOneCar(car);
    }
}
