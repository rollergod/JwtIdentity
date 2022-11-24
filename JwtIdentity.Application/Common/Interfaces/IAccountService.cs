using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;

namespace JwtIdentity.Application.Common.Interfaces;

public interface IAccountService
{
    Task<Response<string>> EmailConfirmationAsync(string userId, string code);
    Task<Response<ForgotPasswordCodeResponse>> GenerateResetToken(string email);
    Task<Response<string>> SendEmail(string callback, string email);
    Task<Response<string>> ResetPassword(string email, string password, string token);
}