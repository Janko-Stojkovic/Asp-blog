using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class LogEntriesDTO
    {
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UseCasename { get; set; }
    }
}
