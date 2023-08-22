using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.User;
using ASP_Projekat.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.User
{
    public class EfSearchUsersQuery : ISearchUsersQuery
    {
        private BlogDbContext _context;
        private readonly IApplicationUser _user;

        public EfSearchUsersQuery(BlogDbContext context, IApplicationUser user)
        {
            _context = context;
            _user = user;
        }

        public int Id => 15;

        public string Name => "Pretraga user po kljucnoj reci";

        public string Description => "Pretraga user po kljucnoj reci";

        public List<UserDTO> Execute(SearchUser search)
        {

            var query = _context.Users.Include(x => x.Blogs).ThenInclude(x => x.User)
                                      .Include(x => x.Comments).ThenInclude(x => x.User)
                                      .Include(x => x.Image).AsQueryable();

            if (!string.IsNullOrEmpty(search.keyword))
            {
                query = query.Where(x => x.Username.Contains(search.keyword) ||
                                     x.Email.Contains(search.keyword) ||
                                     x.FirstName.Contains(search.keyword) ||
                                     x.LastName.Contains(search.keyword));
            }
            if (search.HasBlogs.HasValue)
            {
                if (search.HasBlogs.Value)
                {
                    query = query.Where(x => x.Blogs.Any());

                }
                if (!search.HasBlogs.Value)
                {
                    query = query.Where(x => !x.Blogs.Any());

                }
            }
            if (search.HasComments.HasValue)
            {
                if (search.HasComments.Value)
                {
                    query = query.Where(x => x.Comments.Any());

                }
                if (!search.HasComments.Value)
                {
                    query = query.Where(x => !x.Comments.Any());

                }
            }

            var data = query.Select(x => new UserDTO
            {
                Email = x.Email,
                UserName = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Role = _context.Roles.Select(x => x.RoleName).First(),
                ProfilImage = _context.Images.Select(x => x.ImageUrl).First(),
                Blogs = _context.Blogs.Where(z => z.UserId == x.Id).Select(y => new UserBlogDTO
                {
                    BlogContent = y.BlogContent,
                    id = y.Id,
                }).ToList(),
                Comments = _context.Comments.Where(z => z.UserId == x.Id).Select(y => new UserCommentsDTO
                {
                    BlogId = y.BlogId,
                    ParentId = y.ParentId,
                    CommentContent = y.CommentContent
                }).ToList()
            }).ToList();


            return (data);



        }
    }
}
