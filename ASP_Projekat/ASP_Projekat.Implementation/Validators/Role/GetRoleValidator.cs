using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Role
{
    public class GetRoleValidator : AbstractValidator<int>
    {
        public GetRoleValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x).Must(x => context.Roles.Any(c => c.Id == x))
                           .WithMessage("This Role Doesn`t Exist In Database");
        }
    }
}
