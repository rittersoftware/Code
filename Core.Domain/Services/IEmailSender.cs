using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}
