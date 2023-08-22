using ASP_Projekat.Application.UseCases;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.Blog;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using ASP_Projekat.Domain.Entities;
using ASP_Projekat.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.Blog
{
    public class EfSearchBlogQuery : ISearchBlogsQuery
    {

        private BlogDbContext _context;

        public EfSearchBlogQuery(BlogDbContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Search Blogs";

        public string Description => "Search Blogs With Provided Keyword";

        public PageResponse<BlogDTO> Execute(SearchBlog search)
        {
            var query = _context.Blogs.Include(x => x.User)
                                      .Include(x => x.Comments)
                                      .Include(x => x.BlogReactions).ThenInclude(x => x.Reaction)
                                      .Include(x => x.BlogTags).ThenInclude(x => x.Tag)
                                      .Include(x => x.BlogImages).ThenInclude(x => x.Image).AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.BlogContent.Contains(search.Keyword) ||
                        x.Comments.Any(c => c.CommentContent.Contains(search.Keyword)) ||
                        x.User.Username.Contains(search.Keyword) ||
                        x.User.FirstName.Contains(search.Keyword) ||
                        x.User.LastName.Contains(search.Keyword) ||
                        x.BlogTags.Any(t => t.Tag.TagText.Contains(search.Keyword)));
            }

            if (search.HasReactions.HasValue)
            {
                if (search.HasReactions.Value)
                {
                    query = query.Where(x => x.BlogReactions.Any());

                }
                if (!search.HasReactions.Value)
                {
                    query = query.Where(x => !x.BlogReactions.Any());

                }
            }
            var data = query.ToPagedResponse<Domain.Entities.Blog, BlogDTO>(search, y => new BlogDTO
            {
                CreatedAt = y.CreatedAt,
                Id = y.Id,
                BlogContent = y.BlogContent,
                FullName = _context.Users.Where(x => x.Id == y.UserId).Select(x => x.FirstName).First() + " " + _context.Users.Where(x => x.Id == y.UserId).Select(x => x.LastName).First(),
                Username = _context.Users.Where(x => x.Id == y.UserId).Select(x => x.Username).First(),
                BlogTags = _context.BlogTags.Where(x => x.BlogId == y.Id).Select(x => new BlogTagDTO
                {
                    TagId = x.TagId,
                }).ToList(),

                BlogImages = _context.BlogImages.Where(x => x.BlogId == y.Id).Select(x => new BlogImageDTO
                {
                    ImageId = x.ImageId,
                }).ToList(),
                BlogComments = _context.Comments.Where(x => x.BlogId == y.Id).Select(x => new BlogCommentsDTO
                {
                    Username = x.User.Username,
                    ParentId = x.ParentId,
                    CommentContent = x.CommentContent,
                }).ToList(),
                BlogReactions = _context.BlogReactions.Where(x => x.BlogId == y.Id).Select(x => new BlogReactionsDTO
                {
                    ReactionName = x.Reaction.ReactionName,
                    UserReacted = x.User.Username
                }).ToList()

            });
            return (data);

        }

    }
}
