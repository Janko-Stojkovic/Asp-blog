using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Reaction
{
    public class DeleteReactionValidator : AbstractValidator<int>
    {
        public DeleteReactionValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Reactions.Any(c => c.Id == x))
               .WithMessage("This reaction doesnt exists in database");


        }
    }
}
