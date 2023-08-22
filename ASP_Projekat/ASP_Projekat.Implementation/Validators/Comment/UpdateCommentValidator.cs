using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.Comment
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDTO>
    {
        public UpdateCommentValidator(BlogDbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Comment).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).Must(x => context.Comments.Any(y => y.Id == x))
                .WithMessage("This comment doesnt exist in database");
        }
    }
}
