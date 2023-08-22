using ASP_Projekat.Application.Exceptions;
using ASP_Projekat.Application.Logging;
using ASP_Projekat.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCaseHandling
{
    public interface ICommandHandler
    {
        void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data);

    }
    public class CommandHandler : ICommandHandler
    {
        private IApplicationUser _user;
        private IUseCaseLogger _logger;

        public CommandHandler(IApplicationUser user, IUseCaseLogger logger)
        {
            _user = user;
            _logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            if (command.Id != 17 && !_user.UseCaseIds.Contains(command.Id))
            {
                throw new UnauthorizedUserUseCaseException(_user.Username, command.Name);
            }

            _logger.Add(new UseCaseLogEntry
            {
                User = _user.Username,
                UserId = _user.Id,
                Data = data,
                UseCaseName = command.Name
            });

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            command.Execute(data);

            stopwatch.Stop();

            Console.WriteLine("Execution time:" + stopwatch.ElapsedMilliseconds + " UseCase: " + command.Name + " User: " + _user.Username);
        }
    }
}
