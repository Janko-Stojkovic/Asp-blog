using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Blog;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Blog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Blog
{
    public class EfDeleteBlogCommand : IDeleteBlogCommand
    {
        private BlogDbContext _context;
        private DeleteBlogValidator _validator;
        private IApplicationUser _user;

        public EfDeleteBlogCommand(BlogDbContext context, DeleteBlogValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public int Id => 19;

        public string Name => "Delete Blog";

        public string Description => "Delete Blog";

        public void Execute(int request)
        {
            _validator.ValidateAndThrow(request);
            var data = _context.Blogs.Find(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;
            data.DeletedBy = _user.Username;
            _context.SaveChanges();
        }
    }
}
