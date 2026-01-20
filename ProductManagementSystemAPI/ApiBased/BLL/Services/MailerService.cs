using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MailerService
    {
        public static void Send(string to, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(
                "pw728574@gmail.com",
                "zizf xdcq jgss pdzv"
            );

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("pw728574@gmail.com");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            smtp.Send(mail);
        }
    }
}
