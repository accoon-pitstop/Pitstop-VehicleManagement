using Accoon.Pitshop.VehicleApi.Application.Interfaces.Database;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomerList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.GetVehicleList
{
    public class GetVehiclesListQueryHandler : IRequestHandler<GetVehicleListQuery, GetVehiclesListViewModel>
    {
        private readonly IDatabaseContext database;
        private readonly IMapper mapper;

        public GetVehiclesListQueryHandler(IDatabaseContext cqrscaDbContext, IMapper mapper)
        {
            this.database = cqrscaDbContext;
            this.mapper = mapper;
        }

        public async Task<GetVehiclesListViewModel> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {
            // get from database
            var vehicleList = await this.database.Vehicles
                .ProjectTo<GetVehicleListModel>(this.mapper.ConfigurationProvider).ToListAsync<GetVehicleListModel>(cancellationToken);

            var model = new GetVehiclesListViewModel()
            {
                Vehicles = vehicleList
            };

            return model;
        }
    }
}
