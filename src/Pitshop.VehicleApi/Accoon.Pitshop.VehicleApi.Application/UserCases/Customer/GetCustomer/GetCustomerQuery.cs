using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerModel>
    {
        public Guid Id { get; set; }
    }
}
