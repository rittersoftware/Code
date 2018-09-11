using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Core.Domain.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            this.logger = logger;
        }
        public Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            this.logger.LogInformation($"{message}");
            return Task.FromResult(true);
        }
    }
}
