using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Blog
{
    public class GetBlogValidator : AbstractValidator<int>
    {
        public GetBlogValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(id => id).NotEmpty();
            RuleFor(x => x).Must(x => context.Blogs.Any(c => c.Id == x)).WithMessage("This blog doesn`t exist in database");

        }
    }
}
