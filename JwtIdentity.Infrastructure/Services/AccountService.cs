using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace JwtIdentity.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _sendEmail;
    public AccountService(UserManager<User> userManager,
                          IEmailService sendEmail,
                          IMapper mapper)
    {
        _userManager = userManager;
        _sendEmail = sendEmail;
        _mapper = mapper;
    }

    public async Task<Response<ForgotPasswordCodeResponse>> GenerateResetToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return Response<ForgotPasswordCodeResponse>.Fail($"User with current {email} email doesnt exist");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var response = _mapper.Map<ForgotPasswordCodeResponse>((user, token));

        return Response<ForgotPasswordCodeResponse>.Success(
            data: response,
            message: $"Token generated successfully"
        );
    }

    public async Task<Response<string>> SendEmail(string message, string email)
    {
        var sendingEmail = await _sendEmail.SendEmailAsync(
            toEmail: email,
            message: message);

        if (sendingEmail)
            return Response<string>.Success("Check your email");

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

    public async Task<Response<string>> EmailConfirmationAsync(string userId, string code)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return Response<string>.Fail($"User with current {userId} userId doesnt exist");

        var isEmailConfirmed = await _userManager.ConfirmEmailAsync(user, code);

        string status = isEmailConfirmed.Succeeded ?
            "Confirmation email completed" : "Your email is not confirmed, try again";

        if (!isEmailConfirmed.Succeeded)
            return Response<string>.Fail("Your email is not confirmed, try again");

        return Response<string>.Success("Confirmation email completed");
    }
}
