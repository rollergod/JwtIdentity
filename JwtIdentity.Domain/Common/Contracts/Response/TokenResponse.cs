using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Domain.Common.Contracts.Response;

public class TokenResponse
{
    public User User { get; set; }
    public string Token { get; set; }
}