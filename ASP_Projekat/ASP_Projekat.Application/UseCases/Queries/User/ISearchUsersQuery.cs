using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.Queries.User
{
    public interface ISearchUsersQuery : IQuery<SearchUser, List<UserDTO>>
    {
    }
}
