using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? ProfilImage { get; set; }
        public ICollection<UserBlogDTO> Blogs { get; set; }
        public ICollection<UserCommentsDTO> Comments { get; set; }
    }

    public class UserBlogDTO
    {
        public int id { get; set; }
        public string BlogContent { get; set; }
    }

    public class UserCommentsDTO
    {
        public string CommentContent { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }
    }
}
