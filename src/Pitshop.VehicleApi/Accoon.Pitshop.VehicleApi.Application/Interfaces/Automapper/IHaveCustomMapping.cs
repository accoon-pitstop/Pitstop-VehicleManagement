using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.Interfaces.Automapper
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
