using Diplomski.Core.Constants;
using Diplomski.Core.Settings;
using Diplomski.Infrastructure.EfModels;
using Diplomski.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Diplomski.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddServicesToDependencyInjection();
            builder.Services.AddSettingsToDependencyInjection(builder.Configuration);
            builder.Services.AddValidatorsToDependencyInjection();

            builder.Services.AddDbContext<DiplomskiDbContext>(maker =>
            {
                maker.UseSqlServer(CreateConnectionString(builder.Configuration));
                maker.EnableSensitiveDataLogging(false);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

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
            DatabaseSettings databaseSettings = configuration.GetSection(DiplomskiConstants.DatabaseSection).Get<DatabaseSettings>();

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