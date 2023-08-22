using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Tag
{
    public class GetTagValidator : AbstractValidator<int>
    {
        public GetTagValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Tags.Any(c => c.Id == x))
               .WithMessage("This Tag Doesn`t Exist In Database.");
        }
    }
}
