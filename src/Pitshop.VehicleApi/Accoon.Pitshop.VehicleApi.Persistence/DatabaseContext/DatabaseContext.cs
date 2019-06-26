﻿using Accoon.Pitshop.VehicleApi.Application.Interfaces.Database;
using Accoon.Pitshop.VehicleApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accoon.Pitshop.VehicleApi.Persistence.DatabaseContext
{
    public class DefaultDatabaseContext : DbContext, IDatabaseContext
    {
        // constructor
        public DefaultDatabaseContext(DbContextOptions<DefaultDatabaseContext> options) : base(options)
        {

        }

        // database entities
        public DbSet<Customer> Customers { get; set; }

        // register entity configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultDatabaseContext).Assembly);
        }



    }
}

// Add migrations
// Add-Migration InitMigration -Project Accoon.Pitshop.VehicleApi.Persistence -StartupProject Accoon.Api -Context DefaultDatabaseContext
// update-database -Project Accoon.Pitshop.VehicleApi.Persistence -StartupProject Accoon.Api