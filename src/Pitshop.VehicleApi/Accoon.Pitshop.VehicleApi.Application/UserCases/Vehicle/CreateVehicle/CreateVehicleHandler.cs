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
        private readonly IDatabaseContext cqrscaDbContext;

        public CreateVehicleHandler(IMediator mediator, IDatabaseContext context)
        {
            this.mediator = mediator;
            this.cqrscaDbContext = context;
        }

        public async Task<VehicleCreated> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Accoon.Pitshop.VehicleApi.Domain.Entities.Customer()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Age = request.Age
            };
            //insert customer to database
            this.cqrscaDbContext.Customers.Add(entity);

            await this.cqrscaDbContext.SaveChangesAsync(cancellationToken);

            var newcustomer = new VehicleCreated { CustomerId = entity.Id };
            await this.mediator.Publish(newcustomer, cancellationToken);

            return newcustomer;
        }
    }
}
