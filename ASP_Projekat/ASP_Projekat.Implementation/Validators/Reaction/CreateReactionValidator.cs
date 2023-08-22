using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Reaction
{
    public class CreateReactionValidator : AbstractValidator<CreateReactionDTO>
    {
        public CreateReactionValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ReactionName).NotEmpty().WithMessage("Name is required ");
            RuleFor(x => x.ReactionName).Must(x => !context.Reactions.Any(u => u.ReactionName == x))
                .WithMessage("This Reaction Name Is Taken");
            RuleFor(x => x.ImageId).Must(x => context.Images.Any(y => y.Id == x))
                .WithMessage("This Image Doesn`t Exist. Please Upload New Image, Or Use Our Images");

        }
    }
}
