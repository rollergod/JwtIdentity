using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Domain.Common.Contracts.Response;

public class LoginResponse
{
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}