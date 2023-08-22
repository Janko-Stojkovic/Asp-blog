using ASP_Projekat.Application.UseCases.DTO.Searches;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Implementation.Validators.LogEntry
{
    public class LogEntryValidator : AbstractValidator<SearchLogEntries>
    {
        public LogEntryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Keyword).NotEmpty();

        }
    }
}
