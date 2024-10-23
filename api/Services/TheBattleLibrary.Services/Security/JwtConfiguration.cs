using Microsoft.Extensions.Configuration;

namespace TheBattleLibrary.Services.Security;

public class JwtConfiguration
{
    private const string SecurityKeyNotSetMessage = "Required value 'Security:Key' not set in configuration";
    private const string IssuerNotSetMessage = "Required value 'Security:Issuer' not set in configuration";
    private const string AudienceNotSetMessage = "Required value 'Security:Audience' not set in configuration";


    public required byte[] Key { get; init; }
    public int JwtTimeoutSeconds { get; init; }
    public bool JwtTimeoutSecondsConfigured { get; init; } = true;
    public required string Issuer { get; init; }
    public required string Audience { get; init; }

    public static JwtConfiguration GetConfiguration(IConfiguration configuration)
    {
        // the security key is required for the JWTs
        var key = configuration.GetValue<string>("Security:Key");

        if (string.IsNullOrEmpty(key))
        {
            throw new KeyNotFoundException(SecurityKeyNotSetMessage);
        }


        // the issuer and audience are required
        var issuer = configuration.GetValue<string>("Security:Issuer");

        if (string.IsNullOrEmpty(issuer))
        {
            throw new KeyNotFoundException(IssuerNotSetMessage);
        }

        var audience = configuration.GetValue<string>("Security:Audience");

        if (string.IsNullOrEmpty(audience))
        {
            throw new KeyNotFoundException(AudienceNotSetMessage);
        }

        // pull in configured jwt timeout time in seconds
        var configTimeout = configuration.GetValue<int?>("Security:JwtTimeoutSeconds");

        return new JwtConfiguration
        {
            Issuer = issuer,
            Audience = audience,
            JwtTimeoutSeconds = configTimeout.GetValueOrDefault(24 * 60 * 60),
            JwtTimeoutSecondsConfigured = configTimeout.HasValue,
            Key = System.Text.Encoding.UTF8.GetBytes(key)
        };
    } 
}
