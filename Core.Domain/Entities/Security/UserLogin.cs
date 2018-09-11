using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities.Security
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual User User { get; set; }
        public string RefreshToken { get; set; }
    }
}
