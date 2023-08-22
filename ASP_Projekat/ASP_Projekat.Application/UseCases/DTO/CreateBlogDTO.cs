using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class CreateBlogDTO
    {
        public int UserId { get; set; }
        public string? BlogContent { get; set; }
        public ICollection<BlogImageDTO>? BlogImages { get; set; }
        public ICollection<BlogTagDTO>? BlogTags { get; set; }

    }
    public class BlogImageDTO
    {
        public int ImageId { get; set; }
    }
    public class BlogTagDTO
    {
        public int TagId { get; set; }
    }
}
