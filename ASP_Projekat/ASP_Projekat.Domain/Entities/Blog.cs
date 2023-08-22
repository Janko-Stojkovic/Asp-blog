using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class Blog : Entity
    {
        public string BlogContent { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<BlogReaction> BlogReactions{ get; set; } = new List<BlogReaction>();
        public virtual ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();


    }
}
