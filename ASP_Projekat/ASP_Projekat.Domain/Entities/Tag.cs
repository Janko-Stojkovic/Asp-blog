using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class Tag : Entity
    {
        public string TagText { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
    }
}
