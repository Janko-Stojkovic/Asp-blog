using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Comment
{
    public class DeleteCommentValidator : AbstractValidator<int>
    {
        public DeleteCommentValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Comments.Any(c => c.Id == x))
               .WithMessage("This comment doesnt exists in database");
       
        }
    }
}
