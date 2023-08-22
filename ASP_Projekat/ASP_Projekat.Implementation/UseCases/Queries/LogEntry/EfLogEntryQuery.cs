using ASP_Projekat.Application;
using ASP_Projekat.Application.UseCases.DTO;
using ASP_Projekat.Application.UseCases.DTO.Searches;
using ASP_Projekat.Application.UseCases.Queries.Blog;
using ASP_Projekat.Application.UseCases.Queries.LogEntries;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Implementation.Validators.LogEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.UseCases.Queries.LogEntry
{
    public class EfLogEntryQuery : IGetLogEntriesQuery
    {
        private BlogDbContext _context;
        private LogEntryValidator _validator;
        private readonly IApplicationUser _user;
        public EfLogEntryQuery(BlogDbContext context, LogEntryValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 10;

        public string Name => "Search Log Entries With Provided Keywoard Or Dates From To.";

        public string Description => "Search Log Entries With Provided Keywoard Or Dates From To.";




        public List<LogEntriesDTO> Execute(SearchLogEntries search)
        {
            var query = _context.LogEntries.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.UseCaseName.Contains(search.Keyword) || x.Actor.Contains(search.Keyword));
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.CreatedAt <= search.DateTo.Value);
            }
            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt >= search.DateFrom.Value);
            }


            var data = query.Select(x => new LogEntriesDTO
            {
                Username = x.Actor,
                CreatedAt = x.CreatedAt,
                UseCasename = x.UseCaseName,
            }).ToList();

            return (data);
        }
    }
}
