using Accoon.Pitshop.VehicleApi.Application.Interfaces.Automapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomer
{
    public class GetVehicleModel : IMapFrom<Accoon.Pitshop.VehicleApi.Domain.Entities.Vehicle>
    {
        public Guid Id { get; set; }
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }
    }
}
