using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.ReactOnBlog
{
    public class ReactOnBlogValidator : AbstractValidator<ReactOnBlogDTO>
    {
        
        public ReactOnBlogValidator(BlogDbContext context, IApplicationUser user)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;


            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.ReactionId).NotEmpty();



            RuleFor(x => x.BlogId).Must(x => context.Blogs.Any(y => y.Id == x))
                .WithMessage("This Blog Doesn`t Exist.");

            RuleFor(x => x.ReactionId).Must(x => context.Reactions.Any(y => y.Id == x))
             .WithMessage("This Reaction Doesn`t Exist.");

            RuleFor(dto => dto)
            .Must((dto, context) => !ReactionAlreadyExists(user.Id, dto.BlogId))
            .WithMessage("You Already Reacted On This Blog.");

        }
        private bool ReactionAlreadyExists(int userId, int blogId)
        {
            using (var context = new BlogDbContext())
            {
                var existingReaction = context.BlogReactions
                    .FirstOrDefault(r => r.UserId == userId && r.BlogId == blogId);

                return existingReaction != null;
            }
        }
    }
}
