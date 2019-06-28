using Accoon.Pitshop.VehicleApi.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Persistence.Infastructure
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<VehicleDatabaseContext>
    {
        public DatabaseContextFactory()
        {
            Debugger.Launch();
        }

        public VehicleDatabaseContext CreateDbContext(string[] args)
        {
            var currentDirentory = Path.Combine(Directory.GetCurrentDirectory());
            Console.WriteLine(currentDirentory);
            var resolver = new DependencyResolver
            {
                CurrentDirectory = currentDirentory

            };

            return resolver.ServiceProvider.GetService(typeof(VehicleDatabaseContext)) as VehicleDatabaseContext;
        }
    }
}
