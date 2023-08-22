using ASP_Projekat.Application.UseCases.Commands.ReactOnBlog;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.ReactOnBlog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.ReactOnBlog
{
    public class EfDeleteReactOnBlogCommand : IDeleteReactionOnBlogCommand
    {
        private BlogDbContext _context;
        private DeleteReactionOnBlogValidator _validator;


        public EfDeleteReactOnBlogCommand(BlogDbContext context, DeleteReactionOnBlogValidator validator)
        {
            _context = context;
            _validator = validator;

        }
        public int Id => 28;

        public string Name => "Delete Reaction On Blog";

        public string Description => "Delete Reaction On Blog";

        public void Execute(List<int> request)
        {
            _validator.ValidateAndThrow(request);

            var data = _context.BlogReactions.Where(x => x.BlogId == request.First())
               .Where(x => x.ReactionId == request.ElementAt(1))
               .Where(x => x.UserId == request.ElementAt(2))
               .FirstOrDefault();

            data.DeletedAt = DateTime.UtcNow;

            _context.BlogReactions.Remove(data);

            _context.SaveChanges();

        }

    }
}
