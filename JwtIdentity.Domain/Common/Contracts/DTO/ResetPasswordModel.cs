namespace JwtIdentity.Domain.Common.Contracts.DTO;

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string Password { get; set; }

    public string Code { get; set; }
}