using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class Reaction : Entity
    {
        public string ReactionName { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }    
        public ICollection<BlogReaction> Reactions { get; set; } = new List<BlogReaction>();
    }
}
