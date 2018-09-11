using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public interface ISmsSender
    {
        Task<bool> SendSmsAsync(string number, string message);
    }
}
