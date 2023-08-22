using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.Emails
{
    public interface IEmailSender
    {
        void Send(EmailDTO mail);
    }
}
