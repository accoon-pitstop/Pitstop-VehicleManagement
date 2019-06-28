using Accoon.Pitshop.VehicleApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Persistence.Configurations
{
    public class VehicleConfiguaration: IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasKey(e => e.LicenseNumber);
            builder.HasKey(e => e.Brand);
            builder.HasKey(e => e.Type);
        }
    }
}
