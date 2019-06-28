using Accoon.Pitshop.VehicleApi.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Persistence.Infastructure
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            // Set up Dependency Injection
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
                (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = CurrentDirectory
                });

            // Register DbContext class
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration().GetConnectionString("VehicleContext");
                var optionsBuilder = new DbContextOptionsBuilder<VehicleDatabaseContext>();
                optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Accoon.Pitshop.VehicleApi.Persistence"));
                return new VehicleDatabaseContext(optionsBuilder.Options);
            });
        }
    }
}
