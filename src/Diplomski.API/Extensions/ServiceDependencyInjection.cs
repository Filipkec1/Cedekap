using Diplomski.Core.Services;
using Diplomski.Core.Services.Implementations;
using Diplomski.Core.UnitsOfWork;
using Diplomski.Infrastructure.EfUnitsOfWork;

namespace Diplomski.API.Extensions
{
    public static class ServiceDependencyInjection
    {
        /// <summary>
        /// Adds services to dependency injection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesToDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
