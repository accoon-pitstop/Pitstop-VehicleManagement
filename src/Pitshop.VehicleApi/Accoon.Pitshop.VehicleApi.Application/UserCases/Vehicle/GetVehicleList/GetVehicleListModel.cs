using Accoon.Pitshop.VehicleApi.Application.Interfaces.Automapper;
using AutoMapper;
using System;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomerList
{
    public class GetVehicleListModel : IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Accoon.Pitshop.VehicleApi.Domain.Entities.Vehicle, GetVehicleListModel>()
               .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
               .ForMember(cDTO => cDTO.LicenseNumber, opt => opt.MapFrom(c => c.LicenseNumber))
               .ForMember(cDTO => cDTO.Brand, opt => opt.MapFrom(c => c.Brand))
               .ForMember(cDTO => cDTO.Type, opt => opt.MapFrom(c => c.Type))
               .ForMember(cDTO => cDTO.OwnerId, opt => opt.MapFrom(c => c.OwnerId));
        }
    }
}