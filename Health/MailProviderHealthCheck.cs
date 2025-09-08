using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SurveyBasket.Health
{
    public class MailProviderHealthCheck(IOptions<MailSettings> mailSettings) : IHealthCheck
    {
        private readonly MailSettings _mailSettings = mailSettings.Value;
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using var smtp = new SmtpClient();

                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

                return await Task.FromResult(HealthCheckResult.Healthy("Mail provider is reachable."));
            }
            catch (Exception exception)
            {
                return await Task.FromResult(HealthCheckResult.Unhealthy("Mail provider is not reachable.", exception));
            }
        }
    }
}
