using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.User
{
    public class DeleteUserValidator : AbstractValidator<int>
    {
        public DeleteUserValidator(BlogDbContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Users.Any(c => c.Id == x))
               .WithMessage("User With Provided ID Doesn`t exist in database.");
        }
    }
}
