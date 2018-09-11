using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities.Security
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public virtual User User { get; set; }
    }
}
