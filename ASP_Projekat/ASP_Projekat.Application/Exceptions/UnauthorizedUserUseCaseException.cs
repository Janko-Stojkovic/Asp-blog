using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.Exceptions
{
    public class UnauthorizedUserUseCaseException : Exception {
        public UnauthorizedUserUseCaseException(string username, string usecasename) 
            : base($"Unauthorized user {username} has tried to execute {usecasename}")
        {

        }
    }
}
