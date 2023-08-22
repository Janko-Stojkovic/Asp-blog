using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Tag
{
    public class CreateTagValidator : AbstractValidator<CreateTagDTO>
    {
        public CreateTagValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Tag).NotEmpty().WithMessage("Tag Name Is Required.");
            RuleFor(x => x.Tag).Must(x => !context.Tags.Any(u => u.TagText == x))
                .WithMessage("This Tag Already Exist.");

        }
    }
}
