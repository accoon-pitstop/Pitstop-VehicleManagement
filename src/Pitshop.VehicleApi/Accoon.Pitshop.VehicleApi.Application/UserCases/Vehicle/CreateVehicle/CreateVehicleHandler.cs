using Accoon.Pitshop.VehicleApi.Application.Interfaces.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accoon.Pitshop.VehicleApi.Domain.Entities;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.CreateVehicle
{ 
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, VehicleCreated>
    {
        private readonly IMediator mediator;
        private readonly IDatabaseContext database;

        public CreateVehicleHandler(IMediator mediator, IDatabaseContext context)
        {
            this.mediator = mediator;
            this.database = context;
        }

        public async Task<VehicleCreated> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Accoon.Pitshop.VehicleApi.Domain.Entities.Vehicle()
            {
                Id = Guid.NewGuid(),
                Brand = request.Brand,
                LicenseNumber = request.LicenseNumber,
                Type = request.Type
            };
            //insert customer to database
            this.database.Vehicles.Add(entity);

            await this.database.SaveChangesAsync(cancellationToken);

            var newcustomer = new VehicleCreated { VehicleId = entity.Id };
            await this.mediator.Publish(newcustomer, cancellationToken);

            return newcustomer;
        }
    }
}
