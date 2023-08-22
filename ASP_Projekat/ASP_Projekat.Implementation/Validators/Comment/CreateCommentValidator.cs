using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Comment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDTO>
    {
        public CreateCommentValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
          
            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.BlogId).Must(x => context.Blogs.Any(y => y.Id == x))
              .WithMessage("This Blog Doesn`t Exist In Our Database");

            RuleFor(x => x.ParentId)
                    .Must(x => x == null || context.Comments.Any(c => c.Id == x && c.IsActive))
                    .WithMessage("Parent comment doesn't exist.");
            RuleFor(x => x.Comment).NotEmpty();
        }
    }
}
