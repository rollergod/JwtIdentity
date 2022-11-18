using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace JwtIdentity.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _sendEmail;
    public AccountService(UserManager<User> userManager, IEmailService sendEmail)
    {
        _userManager = userManager;
        _sendEmail = sendEmail;
    }

    public async Task<Response<ForgotPasswordCodeResponse>> GenerateResetToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return Response<ForgotPasswordCodeResponse>.Fail($"User with current {email} email doesnt exist");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var response = (user, token).Adapt<ForgotPasswordCodeResponse>();

        return Response<ForgotPasswordCodeResponse>.Success(
            data: response,
            message: $"Token generated successfully"
        );
    }

    public async Task<Response<string>> SendEmail(string callback, string email)
    {
        var sendingEmail = await _sendEmail.SendEmailAsync(
            toEmail: email,
            message: "Please reset password by going to this <a href=\"" + callback + "\">link</a>");

        if (sendingEmail)
            return Response<string>.Success("Reset message sended");

        return Response<string>.Fail("Something went wrong");
    }

    public async Task<Response<string>> ResetPassword(string email, string password, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return Response<string>.Fail($"User with current {email} email doesnt exist");

        var isPasswordChanged = await _userManager.ResetPasswordAsync(user, token, password);

        if (isPasswordChanged.Succeeded)
            return Response<string>.Success("Password changed");

        return Response<string>.Fail($"Cant change password.");
    }
}
