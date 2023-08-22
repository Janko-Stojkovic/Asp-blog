using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ImageSize { get; set; }
        public bool? IsActive { get; set; }
    }
}
