﻿using Accoon.Pitshop.VehicleApi.Application.Entities.Automapper;
using Accoon.Pitshop.VehicleApi.Application.Interfaces.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.Infastructure.Automapper
{
    public static class MapperProfileHelper
    {
        public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select new Map
                    {
                        Source = type.GetInterfaces().First().GetGenericArguments().First(),
                        Destination = type
                    }).ToList();

            return mapsFrom;
        }

        public static IList<IHaveCustomMapping> LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();

            return mapsFrom;
        }
    }
}
