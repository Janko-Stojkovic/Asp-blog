using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO.Searches
{
    public class SearchUser
    {
        public string? keyword { get; set; }
        public bool? HasComments { get; set; }
        public bool? HasBlogs { get; set; }
    }
}
