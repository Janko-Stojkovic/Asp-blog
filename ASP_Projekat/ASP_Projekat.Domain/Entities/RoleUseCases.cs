using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class RoleUseCases
    {
        public int RoleId { get; set; }
        public int UseacaseId { get; set; }

        public virtual Role Role { get; set; }
    }
}
