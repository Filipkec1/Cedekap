using Cedekap.Core.Services;
using Cedekap.Core.Services.Implementations;
using Cedekap.Core.UnitsOfWork;
using Cedekap.Infrastructure.EfUnitsOfWork;

namespace Cedekap.Web.Extensions
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
            services.AddScoped<IArticleService, ArticleService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
