using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Application.Common.Interfaces;

public interface IAuthService
{
    Task<Response<LoginResponse>> Login(string email, string password);
    Task<Response<RegisterResponse>> Register(User model, string password);
}