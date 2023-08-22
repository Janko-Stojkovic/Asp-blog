using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class BlogReaction
    {
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int ReactionId { get; set; }
        public virtual Reaction Reaction { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? ReactedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
