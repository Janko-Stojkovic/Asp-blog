using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string entity) : base ($"Entity {entity} with id {id} doesn`t exist.")
        {
        }
    }
}
