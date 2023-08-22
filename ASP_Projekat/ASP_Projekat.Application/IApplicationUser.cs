using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application
{
    public interface IApplicationUser
    {
        public int Id { get; }
        public string Email { get; }
        public string Username { get; }
        public IEnumerable<int> UseCaseIds { get; }
        
    }
}
