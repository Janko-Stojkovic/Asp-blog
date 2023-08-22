using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.Reaction;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Reaction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.Reaction
{
    public class EfGetReactionQuery : IGetReactionQuery
    {
        private BlogDbContext _context;
        private GetReactionValidator _validator;
        private readonly IApplicationUser _user;
        public int Id => 11;
        public string Name => "Search For Reaction";

        public string Description => "Search For Reaction";

        public EfGetReactionQuery(BlogDbContext context, GetReactionValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public ReactionDTO Execute(int search)
        {

            Domain.Entities.Reaction reaction = _context.Reactions.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);

            var reactions = new ReactionDTO
            {
                Id = reaction.Id,
                Name = reaction.ReactionName,
                ImagePath = _context.Images.Select(x => x.ImageUrl).First(),

            };
            return (reactions);


        }
    }
}
