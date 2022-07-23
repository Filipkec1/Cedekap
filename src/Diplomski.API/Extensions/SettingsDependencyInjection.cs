using Diplomski.Core.Constants;
using Diplomski.Core.Settings;

namespace Diplomski.API.Extensions
{
    /// <summary>
    /// Defines settings for injection class.
    /// </summary>
    public static class SettingsDependencyInjection
    {
        /// <summary>
        /// Adds validatable settings to dependency injection.
        /// Add and remove unnecessary parameters if needed.
        /// </summary>
        /// <param name="services">Services for extension.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddSettingsToDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.UseConfigurationValidation();

            services.ConfigureValidatableSetting<DatabaseSettings>(configuration.GetSection(DiplomskiConstants.DatabaseSection));

            return services;
        }
    }
}
