using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Domain.Common.Contracts.Response;

public class ForgotPasswordCodeResponse
{
    public User User { get; set; }
    public string Code { get; set; }
}