using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class BlogImage 
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
