using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.CreateVehicle
{
    public class VehicleCreatedHandler : INotificationHandler<VehicleCreated>
    {                
        public Task Handle(VehicleCreated response, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}
