using JwtIdentity.Domain.Common.Contracts.Response;

namespace JwtIdentity.Application.Common.Interfaces;

public interface IAccountService
{
    Task<Response<ForgotPasswordCodeResponse>> GenerateResetToken(string email);
    Task<Response<string>> SendEmail(string callback, string email);
    Task<Response<string>> ResetPassword(string email, string password, string token);
}