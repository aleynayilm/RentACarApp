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
        private readonly Lazy<IDealershipRepository> _dealershipRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IAdminRepository> _adminRepository;
        private readonly Lazy<IDeletedRepository> _deletedRepository;
        private readonly Lazy<IFuelTypeRepository> _fuelTypeRepository;
        private readonly Lazy<IGearTypeReppository> _gearTypeRepository;
        private readonly Lazy<IPaymentStatusRepository> _paymentStatusRepository;
        private readonly Lazy<IPaymentMethodRepository> _paymentMethodRepoitory;
        private readonly Lazy<IResrvationStatusRepository> _resrvationStatusRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(_context));
            _reservationRepository = new Lazy<IReservationRepository>(() => new ReservationRepository(_context));
            _dealershipRepository = new Lazy<IDealershipRepository>(() => new DealershipRepository(_context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(_context));
            _deletedRepository = new Lazy<IDeletedRepository>(() => new DeletedRepository(_context));
            _fuelTypeRepository= new Lazy<IFuelTypeRepository>(() => new FuelTypeRepository(_context));
            _gearTypeRepository= new Lazy<IGearTypeReppository>(() => new GearTypeRepository(_context));
            _paymentStatusRepository= new Lazy<IPaymentStatusRepository>(() => new PaymentStatusRepository(_context));
            _paymentMethodRepoitory = new Lazy<IPaymentMethodRepository>(()=>new PaymentMethodRepository(_context));
            _resrvationStatusRepository= new Lazy<IResrvationStatusRepository>(() => new ReservationStatusRepository(_context));
        }

        public ICarRepository CarR => _carRepository.Value;

        public IReservationRepository ReservationR => _reservationRepository.Value;

        public IDealershipRepository DealershipR => _dealershipRepository.Value;

        public IPaymentRepository PaymentR => _paymentRepository.Value;

        public IUserRepository UserR => _userRepository.Value;

        public IAdminRepository AdminR => _adminRepository.Value;

        public IDeletedRepository DeletedR => _deletedRepository.Value;

        public IFuelTypeRepository FuelTypeR => _fuelTypeRepository.Value;

        public IGearTypeReppository GearTypeR => _gearTypeRepository.Value;

        public IPaymentStatusRepository PaymentStatusR => _paymentStatusRepository.Value;

        public IPaymentMethodRepository PaymentMethodR => _paymentMethodRepoitory.Value;

        public IResrvationStatusRepository ResrvationStatusR => _resrvationStatusRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
