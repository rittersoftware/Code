using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities.Security
{
    public class UserToken : IdentityUserToken<int>
    {
        public virtual User User { get; set; }
    }
}
