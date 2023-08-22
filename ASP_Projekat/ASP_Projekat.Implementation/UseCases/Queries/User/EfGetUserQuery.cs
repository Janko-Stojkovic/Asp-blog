using ASP_Projekat.Application.UseCases;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.Queries.User;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.User
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private BlogDbContext _context;
        private SearchUserIdValidator _validator;
        public EfGetUserQuery(BlogDbContext context, SearchUserIdValidator validator)
        {
            _context = context;
            _validator = validator;

        }
        public int Id => 14;

        public string Name => "Search User With Provided ID";

        public string Description => "Search User With Provided ID";


        UserDTO IQuery<int, UserDTO>.Execute(int search)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == search);
            _validator.ValidateAndThrow(search);

            var users = new UserDTO
            {
                Email = user.Email,
                UserName = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = _context.Roles.Select(x => x.RoleName).First(),
                ProfilImage = _context.Images.Select(x => x.ImageUrl).First(),
                Blogs = _context.Blogs.Where(x => x.UserId == user.Id).Select(x => new UserBlogDTO
                {
                    BlogContent = x.BlogContent,
                    id = x.Id
                }).ToList(),
                Comments = _context.Comments.Where(x => x.UserId == user.Id).Select(x => new UserCommentsDTO
                {
                    BlogId = x.BlogId,
                    CommentContent = x.CommentContent,
                    ParentId = x.ParentId
                }).ToList(),


            };
            return users;
        }
    }
}
