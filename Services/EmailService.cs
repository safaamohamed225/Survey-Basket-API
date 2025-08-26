using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using SurveyBasket.Settings;

namespace SurveyBasket.Services;

public class EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger) : IEmailSender
{
    private readonly MailSettings _mailSettings = mailSettings.Value;
    private readonly ILogger<EmailService> _logger = logger;

    //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //{
    //    var message = new MimeMessage
    //    {
    //        Sender = MailboxAddress.Parse(_mailSettings.Mail),
    //        Subject = subject
    //    };

    //    message.To.Add(MailboxAddress.Parse(email));

    //    var builder = new BodyBuilder
    //    {
    //        HtmlBody = htmlMessage
    //    };

    //    message.Body = builder.ToMessageBody();

    //    using var smtp = new SmtpClient();

    //    _logger.LogInformation("Sending email to {email}", email);

    //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
    //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
    //    await smtp.SendAsync(message);
    //    smtp.Disconnect(true);
    //}

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", _mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };
            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

          
            smtp.CheckCertificateRevocation = false;

            _logger.LogInformation("Connecting to SMTP server: {host}:{port}", _mailSettings.Host, _mailSettings.Port);
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);

         
            if (smtp.IsConnected)
            {
                _logger.LogInformation("Connected successfully. Authenticating with: {email}", _mailSettings.Mail);
                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);

                if (smtp.IsAuthenticated)
                {
                    _logger.LogInformation("Authentication successful. Sending email...");
                    await smtp.SendAsync(message);
                    _logger.LogInformation("Email sent successfully to {email}", email);
                }
            }

            await smtp.DisconnectAsync(true);
        }
        catch (AuthenticationException ex)
        {
            _logger.LogError(ex, "Authentication failed. Check email credentials for {email}", _mailSettings.Mail);
            throw new Exception($"Email authentication failed: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {email}", email);
            throw;
        }
    }
}