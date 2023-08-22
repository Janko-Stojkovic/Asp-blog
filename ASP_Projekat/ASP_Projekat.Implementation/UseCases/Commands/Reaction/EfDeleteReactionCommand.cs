using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Reaction;
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
    public class EfDeleteReactionCommand : IDeleteReactionCommand
    {
        private BlogDbContext _context;
        private DeleteReactionValidator _validator;
        private readonly IApplicationUser _user;
        public EfDeleteReactionCommand(BlogDbContext context, DeleteReactionValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 13;

        public string Name => "Delete Reaction";

        public string Description => "Delete Reaction";

        public void Execute(int request)
        {
            var data = _context.Reactions.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;
            data.DeletedBy = _user.Username;

            _context.SaveChanges();
        }
    }
}
