using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomerList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.GetVehicleList
{
    public class GetVehicleListQuery : IRequest<GetVehiclesListViewModel>
    {
    }
}
