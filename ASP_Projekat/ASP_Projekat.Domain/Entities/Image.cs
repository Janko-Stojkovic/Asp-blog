using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class Image : Entity
    {
        public string ImageUrl { get; set; }
        public int ImageSize { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();
    }
}
