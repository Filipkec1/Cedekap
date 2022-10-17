using FluentValidation.AspNetCore;

namespace Cedekap.Web.Extensions
{
    public static class ValidatorDependencyInjection
    {
        /// <summary>
        /// Adds validators to dependency injection.
        /// Add and remove unnecessary parameters if needed.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddValidatorsToDependencyInjection(this IServiceCollection services)
        {
            //services.AddControllers()
            //    .AddFluentValidation(s =>
            //    {
            //        s.RegisterValidatorsFromAssemblyContaining<Program>();
            //    });

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
