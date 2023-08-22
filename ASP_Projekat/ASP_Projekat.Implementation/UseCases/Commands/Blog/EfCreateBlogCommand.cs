using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.Commands.Blog;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using ASP_Projekat.Domain.Entities;
using ASP_Projekat.Implementation.Validators.Blog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Commands.Blog
{
    public class EfCreateBlogCommand : EfUseCase, ICreateBlogCommand
    {
        private CreateBlogValidator _validator;
        public EfCreateBlogCommand(BlogDbContext context, CreateBlogValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Create Blog";

        public string Description => "Insert New Blog Into Database.";

        public void Execute(CreateBlogDTO request)
        {
            _validator.ValidateAndThrow(request);
            var blog = new Domain.Entities.Blog
            {
                BlogContent = request.BlogContent,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
            };
            Context.Add(blog);
            Context.SaveChanges();

            if (request.BlogTags != null)
            {
                foreach (var t in request.BlogTags)
                {
                    BlogTag blogtags = new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = t.TagId
                    };
                    Context.AddRange(blogtags);
                }
            }
            foreach (var i in request.BlogImages)
            {
                BlogImage blogimages = new BlogImage
                {
                    BlogId = blog.Id,
                    ImageId = i.ImageId
                };
                Context.AddRange(blogimages);
            }
            Context.SaveChanges();
        }
    }
}
