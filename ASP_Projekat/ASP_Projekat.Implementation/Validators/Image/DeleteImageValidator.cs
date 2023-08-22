using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Image
{
    public class DeleteImageValidator : AbstractValidator<int>
    {

        public DeleteImageValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Images.Any(c => c.Id == x))
               .WithMessage("This image doesnt exists in database");


        }
    }
}
