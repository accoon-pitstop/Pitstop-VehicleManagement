using Accoon.Pitshop.VehicleApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Domain.Entities
{
    public class Vehicle: Entity<Guid>
    {
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }
    }
}
