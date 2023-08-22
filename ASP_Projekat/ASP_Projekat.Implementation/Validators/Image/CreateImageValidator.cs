using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Image
{
    public class CreateImageValidator : AbstractValidator<CreateImageDTO>
    {
        public CreateImageValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image path is required ");
            RuleFor(x => x.ImageSize).NotEmpty().WithMessage("Image size is required ");
            RuleFor(x => x.ImageSize).GreaterThan(1).WithMessage("Image size must be greather then 1 MB");
            RuleFor(x => x.ImageUrl).Must(x => !context.Images.Any(u => u.ImageUrl == x))
                .WithMessage("You Can`t Insert Same Address.");

        }
    }
}
