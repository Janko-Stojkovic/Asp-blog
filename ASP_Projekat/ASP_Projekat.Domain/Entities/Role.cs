using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Domain.Entities
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();   
        public virtual ICollection<RoleUseCases> RoleUseCases { get; set; } = new List<RoleUseCases>();
    }
}
