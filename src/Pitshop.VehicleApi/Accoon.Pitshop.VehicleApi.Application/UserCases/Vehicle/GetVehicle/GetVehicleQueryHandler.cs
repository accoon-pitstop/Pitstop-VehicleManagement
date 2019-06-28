using Accoon.Pitshop.VehicleApi.Application.Interfaces.Database;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomer
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, GetVehicleModel>
    {
        private readonly IDatabaseContext database;
        private readonly IMapper mapper;

        public GetVehicleQueryHandler(IDatabaseContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<GetVehicleModel> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await this.database.Vehicles.FirstAsync(o => o.Id.Equals(request.Id));
            var vehiclemodel = this.mapper.Map<GetVehicleModel>(vehicle);
            return vehiclemodel;
        }
    }
}
