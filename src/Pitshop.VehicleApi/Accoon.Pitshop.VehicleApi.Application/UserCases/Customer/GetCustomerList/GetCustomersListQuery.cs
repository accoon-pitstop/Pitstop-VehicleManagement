using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomerList
{
    public class GetCustomersListQuery : IRequest<CustomerListViewModel>
    {
    }
}
