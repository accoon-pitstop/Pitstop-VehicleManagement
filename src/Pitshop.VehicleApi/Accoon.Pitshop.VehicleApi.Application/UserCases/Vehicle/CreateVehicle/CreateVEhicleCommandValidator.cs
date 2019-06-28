using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.CreateVehicle
{ 
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.LicenseNumber).NotEmpty().WithMessage("Name is LicenseNumber"); 
            RuleFor(x => x.Type).NotEmpty().WithMessage("Name is Type"); 
        }
    }
}
