using Cedekap.API.Extensions;
using Cedekap.API.Middlewares;
using Cedekap.Core.Constants;
using Cedekap.Core.Settings;
using Cedekap.Infrastructure.EfModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cedekap.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddServicesToDependencyInjection();
            builder.Services.AddSettingsToDependencyInjection(builder.Configuration);
            builder.Services.AddValidatorsToDependencyInjection();

            builder.Services.AddDbContext<CedekapDbContext>(maker =>
            {
                maker.UseSqlServer(CreateConnectionString(builder.Configuration));
                maker.EnableSensitiveDataLogging(false);
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// Used to create the connection string for the database.
        /// </summary>
        /// <returns>
        /// Set connection string.
        /// </returns>
        private static string CreateConnectionString(ConfigurationManager configuration)
        {
            DatabaseSettings databaseSettings = configuration.GetSection(CedekapConstants.DatabaseSection).Get<DatabaseSettings>();

            string connectionString = "Server={Host};Database={Database};User ID={User};Password={Password};{AdditionalOptions}";

            PropertyInfo[] properties = databaseSettings.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                connectionString = connectionString.Replace("{" + property.Name + "}", (string)property.GetValue(databaseSettings, null));
            }

            return connectionString;
        }
    }
}