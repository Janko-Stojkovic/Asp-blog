using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Role
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDTO>
    {
        public CreateRoleValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.role).NotEmpty().WithMessage("Name is required ");
            RuleFor(x => x.role).Must(x => !context.Roles.Any(u => u.RoleName == x))
                .WithMessage("This Role Name Is Taken.");

        }
    }
}
