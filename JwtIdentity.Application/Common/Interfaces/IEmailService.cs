namespace JwtIdentity.Application.Common.Interfaces;

public interface IEmailService
{
    public Task<bool> SendEmailAsync(string toEmail, string message);
}