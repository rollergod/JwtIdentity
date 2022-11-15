using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
