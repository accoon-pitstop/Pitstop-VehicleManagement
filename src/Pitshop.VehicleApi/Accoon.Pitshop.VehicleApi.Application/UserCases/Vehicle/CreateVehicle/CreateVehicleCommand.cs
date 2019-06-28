using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.CreateVehicle
{
    public class CreateVehicleCommand : IRequest<VehicleCreated>
    {        
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }

    }
}

