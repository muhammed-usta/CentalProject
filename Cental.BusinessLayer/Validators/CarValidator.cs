using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarId).NotEmpty().WithMessage("Car Model cannot be left blank!");
            RuleFor(c => c.Transmission).NotEmpty().WithMessage("Transmission cannot be left blank!");
            RuleFor(c => c.GasType).NotEmpty().WithMessage("Gas type cannot be left blank!");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Price cannot be left blank!");
            RuleFor(c => c.Year).NotEmpty().WithMessage("Year cannot be left blank!");
            RuleFor(c => c.Kilometer).NotEmpty().WithMessage("Kilometer type cannot be left blank!");
            RuleFor(c => c.GearType).NotEmpty().WithMessage("Gear type cannot be left blank!");
            RuleFor(c => c.SeatCount).NotEmpty().WithMessage("Seat count cannot be left blank!");
        }
    }
}
