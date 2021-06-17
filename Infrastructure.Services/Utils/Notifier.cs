using Domain.Core.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Services.Utils
{
    public class Notifier
    {
        private readonly EmailConfiguration _conf;

        public Notifier(IOptions<EmailConfiguration> conf)
        {
            _conf = conf.Value;
        }

        public async Task SendEmailAsync(string toEmail, string password)
        {
            if (string.IsNullOrEmpty(toEmail)) throw new ArgumentException("Recipient message is null or empty");
            MimeMessage message = RegistrationMessage(toEmail);
            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_conf.SmtpServer, _conf.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
            await smtpClient.AuthenticateAsync(toEmail, password);
            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
        }



        private MimeMessage RegistrationMessage(string toEmail)
        {
            string content = "<h1>Confirm your registration</h1><br><p>Proceed to this link in order to finish registration:<br>" +
                $@"<a href=""{_conf.Url}"">Finish</a></p>";
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Booking.NET Service", _conf.Username));
            mailMessage.To.Add(new MailboxAddress(toEmail, toEmail));
            mailMessage.Subject = "Confirm your registration";
            mailMessage.Body = new TextPart("html")
            {
                Text = content
            };
            return mailMessage;
        }
    }
}
