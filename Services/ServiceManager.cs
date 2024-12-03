using Repositories.Contracts;
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
        public ServiceManager(IRepositoryManager repositoryManager) {
            _carServices = new Lazy<ICarServices>(()=> new CarManager(repositoryManager));
            _reservationServices= new Lazy<IReservationServices>(()=> new ReservationManager(repositoryManager));
            _dealershipServices=new Lazy<IDealershipServices>(()=> new DealershipManager(repositoryManager));
            _paymentServices= new Lazy<IPaymentServices>(()=> new PaymentManager(repositoryManager));
            _userServices=new Lazy<IUserServices>(()=> new UserManager(repositoryManager));
        }
        public ICarServices CarServices => _carServices.Value;

        public IReservationServices ReservationServices => _reservationServices.Value;

        public IDealershipServices DealershipServices => _dealershipServices.Value;

        public IPaymentServices PaymentServices => _paymentServices.Value;

        public IUserServices UserServices => _userServices.Value;
    }
}
