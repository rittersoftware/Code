using System.Threading.Tasks;
using Core.Domain.Entities.Security;

namespace Core.Domain.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string username, string password, out User user);
        Task<bool> AddUser(string username, string password);
    }
}
