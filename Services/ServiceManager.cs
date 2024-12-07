using AutoMapper;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICarServices> _carServices;
        private readonly Lazy<IReservationServices> _reservationServices;
        private readonly Lazy<IDealershipServices> _dealershipServices;
        private readonly Lazy<IPaymentServices> _paymentServices;
        private readonly Lazy<IUserServices> _userServices;
        private readonly Lazy<IAdminServices> _adminServices;
        private readonly Lazy<IDeletedServices> _deletedServices;
        private readonly Lazy<IFuelTypeServices> _fuelTypeServices;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerServices logger, IMapper mapper)
        {
            _carServices = new Lazy<ICarServices>(() => new CarManager(repositoryManager, logger, mapper));
            _reservationServices = new Lazy<IReservationServices>(() => new ReservationManager(repositoryManager, mapper));
            _dealershipServices = new Lazy<IDealershipServices>(() => new DealershipManager(repositoryManager, mapper));
            _paymentServices = new Lazy<IPaymentServices>(() => new PaymentManager(repositoryManager, mapper));
            _userServices = new Lazy<IUserServices>(() => new UserManager(repositoryManager, mapper));
            _adminServices = new Lazy<IAdminServices>(() => new AdminManager(repositoryManager, mapper));
            _deletedServices = new Lazy<IDeletedServices>(() => new DeletedManager(repositoryManager));
            _fuelTypeServices= new Lazy<IFuelTypeServices>(() => new FuelTypeManager(repositoryManager, mapper));
        }
        public ICarServices CarServices => _carServices.Value;

        public IReservationServices ReservationServices => _reservationServices.Value;

        public IDealershipServices DealershipServices => _dealershipServices.Value;

        public IPaymentServices PaymentServices => _paymentServices.Value;

        public IUserServices UserServices => _userServices.Value;

        public IAdminServices AdminServices => _adminServices.Value;
        public IDeletedServices DeletedServices => _deletedServices.Value;

        public IFuelTypeServices FuelTypeServices => _fuelTypeServices.Value;

    }

}
