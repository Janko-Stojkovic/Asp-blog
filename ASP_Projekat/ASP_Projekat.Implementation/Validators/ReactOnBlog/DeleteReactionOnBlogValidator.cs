using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.ReactOnBlog
{
    public class DeleteReactionOnBlogValidator : AbstractValidator<List<int>>
    {

        public DeleteReactionOnBlogValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.First()).NotEmpty().WithMessage("BlogId is Required ");
            RuleFor(x => x.ElementAt(1)).NotEmpty().WithMessage("UserID is Required ");
            RuleFor(x => x.ElementAt(2)).NotEmpty().WithMessage("ReactionID is Required ");
            RuleFor(x => x).Must(x => context.BlogReactions.Any(u => u.BlogId == x.First()
            && u.ReactionId == x.ElementAt(1)
            && u.UserId == x.ElementAt(2)
            && u.DeletedAt == null)).WithMessage("Reaction On Blog With Provided DATA Doesn`t Exist In Database.");

        }
    }
}
