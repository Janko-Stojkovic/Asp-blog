using ASP_Projekat.Application;
using ASP_Projekat.Application.Exceptions;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Domain;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_Projekat.Implementation.Validators.Blog;
using FluentValidation;
using ASP_Projekat.Application.UseCases.Queries.Blog;

namespace ASP_Projekat.Implementation.UseCases.Queries.Blog
{
    public class EfGetBlogQuery : IGetBlogQuery
    {
        private readonly BlogDbContext _context;
        private readonly GetBlogValidator _validator;

        public EfGetBlogQuery(BlogDbContext context, GetBlogValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Find Blog With Provided Id";

        public string Description => "Find Blog With Provided Id";

        public BlogDTO Execute(int search)
        {
            _validator.ValidateAndThrow(search);

            Domain.Entities.Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == search && x.IsActive);

            if (blog == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.Entities.Blog));
            }

            return new BlogDTO
            {
                Id = blog.Id,
                BlogContent = blog.BlogContent,
                Username = _context.Users.Where(x => x.Id == blog.UserId).Select(u => u.Username).First(),
                FullName = _context.Users.Where(x => x.Id == blog.UserId).Select(u => u.FirstName).First() + " " + _context.Users.Where(x => x.Id == blog.UserId).Select(u => u.LastName).First(),
                BlogComments = blog.Comments.Select(c => new BlogCommentsDTO
                {
                    CommentContent = c.CommentContent,
                    ParentId = c.ParentId
                }).ToList(),
                BlogReactions = blog.BlogReactions.Select(r => new BlogReactionsDTO
                {
                    ReactionName = r.Reaction.ReactionName,
                    UserReacted = r.User.Username
                }).ToList(),
                BlogImages = blog.BlogImages.Select(i => new BlogImageDTO
                {
                    ImageId = i.ImageId
                }).ToList(),
                BlogTags = blog.BlogTags.Select(t => new BlogTagDTO
                {
                    TagId = t.TagId
                }).ToList()


            };
        }
    }
}
