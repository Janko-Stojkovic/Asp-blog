using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Role
{
    public class DeleteRoleValidator : AbstractValidator<int>
    {
        public DeleteRoleValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(id => id).NotEmpty();
            RuleFor(x => x).Must(x => context.Roles.Any(r => r.Id == x)).WithMessage("This Role Doesn`t Exist.");
        }
    }
}
