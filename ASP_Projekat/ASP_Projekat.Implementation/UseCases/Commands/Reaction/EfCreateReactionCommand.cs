using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Reaction;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Reaction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Reaction
{
    public class EfCreateReactionCommand : ICreateReactionCommand
    {
        private BlogDbContext _context;
        private CreateReactionValidator _validator;
        private readonly IApplicationUser _user;
        public EfCreateReactionCommand(BlogDbContext context, CreateReactionValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 12;

        public string Name => "Create Reaction";

        public string Description => "Adding New Reaction Into Database";

        public void Execute(CreateReactionDTO request)
        {

            _validator.ValidateAndThrow(request);

            Domain.Entities.Reaction reaction = new Domain.Entities.Reaction
            {
                ReactionName = request.ReactionName,
                ImageId = request.ImageId
            };


            _context.Reactions.Add(reaction);

            _context.SaveChanges();



        }
    }
}
