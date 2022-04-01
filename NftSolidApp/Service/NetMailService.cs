using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Service
{
    public class NetMailService : IMailService
    {
        public bool SendMail(string subject, string body, List<string> to)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("denememailservice@gmail.com");

            foreach (var item in to)
            {
                mail.To.Add(item);
            }

            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("denememailservice@gmail.com","deneme123");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";           
            smtp.EnableSsl = true;

            try
            {
                smtp.SendAsync(mail,(object)mail);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
