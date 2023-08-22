using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Blog;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.Blog;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Blog
{
    public class EfUpdateBlogCommand : IUpdateBlogCommand
    {
        private BlogDbContext _context;
        private UpdateBlogValidator _validator;
        private IApplicationUser _user;

        public EfUpdateBlogCommand(BlogDbContext context, UpdateBlogValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public int Id => 25;

        public string Name => "Update Blog";

        public string Description => "Update Blog";

        public void Execute(UpdateBlogDTO request)
        {
            _validator.ValidateAndThrow(request);
            var blog = _context.Blogs.Find(request.Id);
            blog.BlogContent = request.BlogContent;
            blog.UpdatedAt = DateTime.UtcNow;
            blog.UpdatedBy = _user.Username;
            _context.Entry(blog).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
