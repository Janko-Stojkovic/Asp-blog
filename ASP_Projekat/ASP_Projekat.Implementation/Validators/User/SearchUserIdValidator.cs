using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.User
{
    public class SearchUserIdValidator : AbstractValidator<int>
    {
        public SearchUserIdValidator(BlogDbContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(id=>id).NotEmpty();
            RuleFor(x => x).Must(x => context.Users.Any(u => u.Id == x))
                            .WithMessage("User With Provided Id Doesn`t Exist In Database.");
        }
    }
}
