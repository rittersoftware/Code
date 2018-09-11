using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities.Security
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}
