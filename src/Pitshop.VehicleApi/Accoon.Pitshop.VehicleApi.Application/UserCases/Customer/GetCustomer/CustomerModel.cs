using Accoon.Pitshop.VehicleApi.Application.Interfaces.Automapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomer
{
    public class CustomerModel : IMapFrom<Accoon.Pitshop.VehicleApi.Domain.Entities.Customer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
