using ASP_Projekat.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.Queries.Blog
{
    public interface IGetBlogQuery : IQuery<int, BlogDTO>
    {
    }
}
