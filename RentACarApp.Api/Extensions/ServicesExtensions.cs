using Microsoft.EntityFrameworkCore;
using RentACarApp.Api.Repositories.Contracts;
using RentACarApp.Api.Repositories.EFCore;
using RentACarApp.Api.Services;
using RentACarApp.Api.Services.Contracts;

namespace RentACarApp.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration ) {
            services.AddDbContext<RepositoryContext>(options =>
        options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)=>
            services.AddScoped<IRepositoryManager, RepositoryManager >();
        public static void ConfigureServicesManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
