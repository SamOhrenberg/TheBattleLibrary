using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TheBattleLibrary.Services.Security;

public class TokenGenerator
{
    private readonly ILogger<TokenGenerator> _logger;
    private readonly byte[] _key;
    private readonly int _jwtTimeoutSeconds;
    private readonly string _issuer;
    private readonly string _audience;

    public TokenGenerator(ILogger<TokenGenerator> logger, IConfiguration configuration)
    {
        _logger = logger;
        try
        {
            var config = JwtConfiguration.GetConfiguration(configuration);
            _key = config.Key;
            _issuer = config.Issuer;
            _audience = config.Audience;
            _jwtTimeoutSeconds = config.JwtTimeoutSeconds;

            if (!config.JwtTimeoutSecondsConfigured)
            {
                _logger.LogWarning("Security:JwtTimeoutSeconds not configured. Defaulting to one day.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, ex.Message);
            throw;
        }

    }

    public record GenerateTokenResponse(string Token, DateTime ExpiresAt);

    public GenerateTokenResponse GenerateToken(Guid id, string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, username),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddSeconds(_jwtTimeoutSeconds),
            Issuer = _issuer,
            Audience = _audience,
            IssuedAt = DateTime.UtcNow,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new GenerateTokenResponse(tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
    }
}
