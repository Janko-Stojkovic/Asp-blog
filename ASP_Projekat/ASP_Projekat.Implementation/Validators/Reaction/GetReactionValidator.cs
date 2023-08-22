using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Reaction
{
    public class GetReactionValidator : AbstractValidator<int>
    {
        public GetReactionValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Reactions.Any(c => c.Id == x && c.IsActive == true))
               .WithMessage("This Reaction Doesn`t Exist.");


        }
    }
}
