using EmailSender.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmailSender.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig emailConfig;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            this.emailConfig = emailConfig.Value;
        }

        public async Task SendEmailAsync(String email, String subject, String message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(emailConfig.FromName, emailConfig.FromAddress));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

                using (var client = new SmtpClient())
                {
                    client.LocalDomain = emailConfig.LocalDomain;

                    await client.ConnectAsync(emailConfig.MailServerAddress, Convert.ToInt32(emailConfig.MailServerPort), SecureSocketOptions.StartTls).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(emailConfig.UserId, emailConfig.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
