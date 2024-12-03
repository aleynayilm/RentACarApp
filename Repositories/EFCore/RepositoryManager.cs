using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICarRepository> _carRepository;
        private readonly Lazy<IReservationRepository> _reservationRepository;
        private readonly Lazy<IDealershipRepository>_dealershipRepository;
       private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(_context));
            _reservationRepository= new Lazy<IReservationRepository>(() => new ReservationRepository(_context));
            _dealershipRepository= new Lazy<IDealershipRepository>(() => new DealershipRepository(_context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_context));
            _userRepository= new Lazy<IUserRepository>(() => new UserRepository(_context));
        }

        public ICarRepository CarR => _carRepository.Value;

        public IReservationRepository ReservationR => _reservationRepository.Value;

        public IDealershipRepository DealershipR => _dealershipRepository.Value;

        public IPaymentRepository PaymentR => _paymentRepository.Value;

        public IUserRepository UserR => _userRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
