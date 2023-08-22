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
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            

            RuleFor(x => x.Username)
                .Must((user, name) => !context.Users
                .Any(x => x.Username == name && x.Id != user.Id)).WithMessage("This Username Is Taken");

            RuleFor(x => x.Email)
               .Must((user, name) => !context.Users
               .Any(x => x.Email == name && x.Id != user.Id)).WithMessage("This Email Is Taken");
            RuleFor(x => x.ProfileImageId).Must(x => !context.Images.Any(y => y.Id == x))
                .WithMessage("This Image Doesn`t Exist. Please Upload New File, Or Use Our Images");


        }

    }
}
