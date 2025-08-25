using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using SurveyBasket.Settings;

namespace SurveyBasket.Services
{
    public class EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger) : IEmailSender
    {
        private readonly MailSettings _mailSettings = mailSettings.Value;
        private readonly ILogger<EmailService> _logger = logger;

        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    var message = new MimeMessage();

        //    message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        //    message.Sender = MailboxAddress.Parse(_mailSettings.Mail);

        //    message.To.Add(MailboxAddress.Parse(email));
        //    message.Subject = subject;

        //    var builder = new BodyBuilder
        //    {
        //        HtmlBody = htmlMessage
        //    };
        //    message.Body = builder.ToMessageBody();

        //    using var smtp = new SmtpClient();

        //    _logger.LogInformation("Sending Email To: {email}", email);

        //    await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);

        //    _logger.LogInformation("Authenticating with {user} / {pass}", _mailSettings.Mail, _mailSettings.Password);

        //    await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(message);
        //    await smtp.DisconnectAsync(true);
        //}


        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Mail),
                Subject = subject

            };

            message.To.Add(MailboxAddress.Parse(email));

            var builder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };

            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            _logger.LogInformation("Sending Email To: {email}", email);

            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(message);
            smtp.Disconnect(true);
        }
    }
}
