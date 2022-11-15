using Microsoft.AspNetCore.Identity;

namespace JwtIdentity.Domain.IdentityModels
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}