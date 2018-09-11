using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class MessageServices : IEmailSender, ISmsSender
    {
        public Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(true);
        }

        public Task<bool> SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(true);
        }
    }
}
