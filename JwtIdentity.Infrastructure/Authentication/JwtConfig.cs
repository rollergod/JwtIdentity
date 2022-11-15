namespace JwtIdentity.Infrastructure.Authentication;
public class JwtConfig
{
    public const string SectionName = "JwtConfig";
    public string SecretKey { get; set; }
}
