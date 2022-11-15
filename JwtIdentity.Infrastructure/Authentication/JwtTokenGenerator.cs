using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtIdentity.Application.Common;
using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.IdentityModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtIdentity.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtConfig _jwtConfig;

    public JwtTokenGenerator(IOptions<JwtConfig> jwtConfig)
    {
        _jwtConfig = jwtConfig.Value;
    }

    public string GenerateToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var secretKey = Encoding.UTF8.GetBytes(_jwtConfig.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("Id",user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
            }),

            Expires = DateTime.UtcNow.AddMinutes(60),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256
            )
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
    }
}