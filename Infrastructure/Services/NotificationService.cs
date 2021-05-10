using Domain.Helpers;
using Domain.Models.Users;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class NotificationService
    {
        private readonly EmailConfiguration _conf;
        private EmailConfiguration conf;

        public NotificationService(IOptions<EmailConfiguration> conf)
        {
            _conf = conf.Value;
        }

        public NotificationService(EmailConfiguration conf)
        {
            this.conf = conf;
        }

        public async Task SendEmailAsync(string toEmail)
        {
            string content = "<h1>Confirm your registration</h1><br><p>Proceed to this link in order to finish registration:<br>" +
                @"<a href=""https://localhost:5000/api/v1/services"">Finish</a></p>";
            var message = new NotifyMessage(new string[] { toEmail }, "Confirm your registration", content, string.Empty);
            var emailMessage = CreateEmailMessage(message);
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_conf.SmtpServer, _conf.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_conf.Username, _conf.Password);
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                }
                finally
                {
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
        }


        private MimeMessage CreateEmailMessage(NotifyMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_conf.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            var messageBody = new BodyBuilder
            {
                HtmlBody = message.Content
            };
            emailMessage.Body = messageBody.ToMessageBody();
            return emailMessage;
        }
    }
}
