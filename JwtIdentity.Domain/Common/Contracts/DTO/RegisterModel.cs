using System.Text.Json.Serialization;

namespace JwtIdentity.Domain.Common.Contracts.DTO;

public class RegisterModel
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public bool ConfirmedEmail { get; set; } = false;
}