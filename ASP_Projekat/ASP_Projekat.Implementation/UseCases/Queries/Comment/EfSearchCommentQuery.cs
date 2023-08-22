using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.Comment;
using ASP_Projekat.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.Comment
{
    public class EfSearchCommentQuery : ISearchCommentQuery
    {
        private BlogDbContext _context;


        public EfSearchCommentQuery(BlogDbContext context)
        {
            _context = context;
        }

        public int Id => 32;

        public string Name => "Search Comment With Provided Keyword";

        public string Description => "Search Comment With Provided Keyword";

        public List<CommentDTO> Execute(SearchCommentDTO search)
        {
            var query = _context.Comments.Include(x => x.User).AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.CommentContent.Contains(search.Keyword) || x.User.Username.Contains(search.Keyword));
            }
            var data = query.Select(y => new CommentDTO
            {
                CreatedAt = y.CreatedAt,
                Username = _context.Users.Where(x=>x.Id == y.UserId).Select(x=>x.Username).First(),
                Comment = y.CommentContent,
                ChildComments = _context.Comments.Where(x=>x.ParentId == y.Id).Select(x=>new SubCommentsDTO
                {
                    CommentSubContent = x.CommentContent
                }).ToList()
            }).ToList();

            return data;
        }
    }
}
