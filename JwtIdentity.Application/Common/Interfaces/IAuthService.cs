using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Application.Common.Interfaces;

public interface IAuthService
{
    Task<Response<TokenResponse>> Login(string email, string password);
    Task<Response<string>> Register(User model, string password);
}