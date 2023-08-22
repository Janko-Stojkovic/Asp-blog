using ASP_Projekat.Application.Logging;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using ASP_Projekat.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly BlogDbContext _context;

        public EfUseCaseLogger(BlogDbContext context)
        {
            _context = context;
        }
        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Actor = entry.User,
                ActorId = entry.UserId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges(); 
        }
    }
}
