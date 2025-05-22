using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Npu.Infrastructure.Security.Tokens;

internal sealed class JwtBearerTokenValidationConfiguration
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtSettingsOptions _jwtSettings;

    public JwtBearerTokenValidationConfiguration(IOptions<JwtSettingsOptions> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)
            ),
        };
    }

    public void Configure(JwtBearerOptions options)
    {
        Configure(options);
    }
}