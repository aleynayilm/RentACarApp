using RentACarApp.Api.Repositories.Contracts;
using RentACarApp.Api.Services.Contracts;

namespace RentACarApp.Api.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICarServices> _carServices;
        public ServiceManager(IRepositoryManager repositoryManager) {
            _carServices = new Lazy<ICarServices>(()=> new CarManager(repositoryManager));
        }
        public ICarServices CarServices => _carServices.Value;
    }
}
