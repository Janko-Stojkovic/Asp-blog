using ASP_Projekat.Application.Emails;
using System.Net.Mail;

namespace ASP_Projekat.API.Email
{
    public class EmailSend : IEmailSender
    {


        public void Send(EmailDTO message)
        {
            System.Console.WriteLine("Sending email:");
            System.Console.WriteLine("To: " + message.To);
            System.Console.WriteLine("From: " + message.From);
            System.Console.WriteLine("Title: " + message.Title);
            System.Console.WriteLine("Body: " + message.Body);
        }
    }
}
