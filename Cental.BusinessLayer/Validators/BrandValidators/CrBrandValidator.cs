using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.BrandValidators
{
    public class CrBrandValidator : AbstractValidator<CreateBrandDto>
    {
        public CrBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("The brand name cannot be left blank.").MinimumLength(3).WithMessage("The brand name must be at least 3 characters long");

        }
    }
}
