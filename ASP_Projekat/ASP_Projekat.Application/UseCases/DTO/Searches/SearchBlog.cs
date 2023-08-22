using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO.Searches
{
    public class SearchBlog : PageSearch
    {
        public string? Keyword { get; set; }
        public bool? HasReactions { get; set; }
    }
}
