using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Is Required.")
                                 .MaximumLength(60).WithMessage("Maximum number of characters is 60")
                                 .EmailAddress().WithMessage("Invalid Email Format.")
                                 .Must(x => !context.Users.Any(u => u.Email == x)).WithMessage("This Email Is Already In Use.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username Is Required.")
                                    .MaximumLength(35).WithMessage("Maximum number of characters is 35")
                                    .Matches("^(?=.{3,12}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                                    .WithMessage("Invalid username format. Min 3 characters - allowed letters, digits, . and _")
                                    .Must(x => !context.Users.Any(u => u.Username == x))
                                    .WithMessage("This Username Is Already In Use.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Is Required.")
                                    .MaximumLength(120).WithMessage("Maximum number of characters is 120")
                                    .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
                                    .WithMessage("Invalid Password Format. Min 8 characters, 1 lowercase, 1 uppercase and 1 special character");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name Is Required.")
                                     .MaximumLength(25).WithMessage("Maximum number of characters is 25")
                                     .Matches(@"^[A-Z][a-z]{2,}(/s[A-Z][a-z]{2,})?$").WithMessage("Invalid First Name Format");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name Is Required.")
                                    .MaximumLength(25).WithMessage("Maximum number of characters is 25")
                                    .Matches(@"^[A-Z][a-z]{2,}(/s[A-Z][a-z]{2,})?$").WithMessage("Invalid Last Name Format");
        }
    }
}
