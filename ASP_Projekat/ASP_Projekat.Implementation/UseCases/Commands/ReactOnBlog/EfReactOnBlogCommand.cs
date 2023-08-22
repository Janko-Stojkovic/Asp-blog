using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.ReactOnBlog;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain.Entities;
using ASP_Projekat.Implementation.Validators.ReactOnBlog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.ReactOnBlog
{
    public class EfReactOnBlogCommand : IReactOnBlogCommand
    {
        private BlogDbContext _context;
        private ReactOnBlogValidator _validator;
        private IApplicationUser _user;


        public EfReactOnBlogCommand(BlogDbContext context, ReactOnBlogValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 27;

        public string Name => "React On Blog";

        public string Description => "React On Blog";

        public void Execute(ReactOnBlogDTO request)
        {
            _validator.ValidateAndThrow(request);

            Domain.Entities.BlogReaction blogReaction = new Domain.Entities.BlogReaction
            {
                BlogId = request.BlogId,
                UserId = _user.Id,
                IsActive = true,
                ReactedAt = DateTime.UtcNow,
                ReactionId = request.ReactionId
            };

            _context.BlogReactions.Add(blogReaction);

            _context.SaveChanges();

        }
    }
 }
