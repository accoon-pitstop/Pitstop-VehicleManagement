using Accoon.Pitshop.VehicleApi.Application.Interfaces.Database;
using Accoon.Pitshop.VehicleApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accoon.Pitshop.VehicleApi.Persistence.DatabaseContext
{
    public class VehicleDatabaseContext : DbContext, IDatabaseContext
    {
        // constructor
        public VehicleDatabaseContext(DbContextOptions<VehicleDatabaseContext> options) : base(options)
        {

        }

        // database entities
        public DbSet<Vehicle> Vehicles { get; set; }

        // register entity configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleDatabaseContext).Assembly);
        }



    }
}

// Add migrations
// Add-Migration InitMigration -Project Accoon.Pitshop.VehicleApi.Persistence -StartupProject Accoon.Pitshop.VehicleApi.Presenter -Context VehicleDatabaseContext
// update-database -Project Accoon.Pitshop.VehicleApi.Persistence -StartupProject Accoon.Pitshop.VehicleApi.Presenter