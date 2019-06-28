using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Persistence.Infastructure
{
    public interface IEnvironmentService
    {
        string EnvironmentName { get; set; }
    }
}
