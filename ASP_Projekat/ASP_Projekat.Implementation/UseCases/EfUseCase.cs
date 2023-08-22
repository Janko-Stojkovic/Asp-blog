using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(BlogDbContext context)
        {
            Context = context;
        }

        protected BlogDbContext Context { get; }

    }
}
