using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class BlogTag
    {
        public int BlogId { get; set; } 
        public virtual Blog Blog { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
