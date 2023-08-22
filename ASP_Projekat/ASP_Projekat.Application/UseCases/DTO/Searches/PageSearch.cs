using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO.Searches
{
    public class PageSearch 
    {
        public int PerPage { get; set; } = 4;
        public int Page { get; set; } = 1;
    }
}
