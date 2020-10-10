using BaseProject.Web.Config;
using BaseProject.Web.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.Services
{
    public class EmailSender : IEmailSender
    {
       

        public IOptions<EmailSettings> _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await SendEmailViaSeS(email, subject, message);
        }

        private async Task SendEmailViaSeS(string toMailAddress, string subject, string body)
        {
            try
            {
                var fromMailAddress = new MailAddress(_emailSettings.Value.FromEmail, _emailSettings.Value.DisplayName);
                var toAddress = new MailAddress(toMailAddress, toMailAddress);

                string fromPassword = _emailSettings.Value.Password;


                var smtp = new SmtpClient
                {
                    Host = _emailSettings.Value.HostName,
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSettings.Value.UserName, fromPassword)
                };

                using var message = new MailMessage(fromMailAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
     
    }

}
