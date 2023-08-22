using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.Queries.LogEntries
{
    public interface IGetLogEntriesQuery : IQuery<SearchLogEntries, List<LogEntriesDTO>>
    {
    }
}
