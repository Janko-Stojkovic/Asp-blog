using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ProfileImageId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
        public virtual ICollection<BlogReaction> BlogReactions { get; set; } = new List<BlogReaction>();
    }
}
