using Cental.DtoLayer.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.AboutValidators
{
    public class UpAboutValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpAboutValidator()
        {
            RuleFor(x => x.Vision)
           .NotEmpty().WithMessage("Vision cannot be empty.")
           .MinimumLength(10).WithMessage("Vision must be at least 10 characters long.");

            RuleFor(x => x.Mission)
                .NotEmpty().WithMessage("Mission cannot be empty.")
                .MinimumLength(10).WithMessage("Mission must be at least 10 characters long.");

            RuleFor(x => x.Description1)
                .NotEmpty().WithMessage("Description1 cannot be empty.")
                .MaximumLength(500).WithMessage("Description1 cannot exceed 500 characters.");

            RuleFor(x => x.Description2)
                .MaximumLength(500).WithMessage("Description2 cannot exceed 500 characters.");

            RuleFor(x => x.StartYear)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Start Year must be between 1900 and {DateTime.Now.Year}.");

            RuleFor(x => x.Item1)
                .NotEmpty().WithMessage("Item1 cannot be empty.");

            RuleFor(x => x.Item2)
                .NotEmpty().WithMessage("Item2 cannot be empty.");

            RuleFor(x => x.Item3)
                .NotEmpty().WithMessage("Item3 cannot be empty.");

            RuleFor(x => x.Item4)
                .NotEmpty().WithMessage("Item4 cannot be empty.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Name and Surname cannot be empty.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name and Surname can only contain letters and spaces.");

            RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("Job Title cannot be empty.");


        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
