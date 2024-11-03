using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICarRepository> _carRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(_context));
        }

        public ICarRepository CarR => _carRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
