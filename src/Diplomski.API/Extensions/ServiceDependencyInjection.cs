using Microsoft.Extensions.DependencyInjection;

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
            //services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
