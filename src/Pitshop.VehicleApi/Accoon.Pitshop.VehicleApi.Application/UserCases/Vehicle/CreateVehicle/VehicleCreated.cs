using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.CreateVehicle
{
    public class VehicleCreated : INotification
    {
        public Guid CustomerId { get; set; }
    }
}
