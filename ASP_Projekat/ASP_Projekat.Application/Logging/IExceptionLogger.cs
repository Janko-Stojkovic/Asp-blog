using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.Logging
{
    public interface IExceptionLogger
    {
        void Log(AppError ex);
    }
    public class AppError
    {
        public Exception Exception { get; set; }
        public string Username { get; set; }
        public Guid ErrorId { get; set; }
    }
}
