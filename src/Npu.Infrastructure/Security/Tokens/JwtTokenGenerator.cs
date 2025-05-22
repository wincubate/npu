using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Npu.Application.Common.Interfaces.Time;
using Npu.Application.Common.Interfaces.Tokens;
using Npu.Domain.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Npu.Infrastructure.Security.Tokens;

internal class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;
    private readonly JwtSettingsOptions _jwtSettings;

    public JwtTokenGenerator(
        IDateTimeOffsetProvider dateTimeOffsetProvider,
        IOptions<JwtSettingsOptions> jwtSettingsOptions
    )
    {
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
        _jwtSettings = jwtSettingsOptions.Value;
    }

    public Token GenerateToken(
        TokenId tokenId, 
        Identification identification, 
        IReadOnlyCollection<Permission> permissions, 
        IReadOnlyCollection<Role> roles
    )
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Name, identification.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, identification.LastName),
            new(JwtRegisteredClaimNames.Email, identification.Email),
            new("id", tokenId.ToString()),
        ];

        IEnumerable<Claim> permissionClaims = permissions
            .Select<Permission,Claim>(permission =>
                new("permissions", permission.ToString())
            );
        IEnumerable<Claim> roleClaims = roles
            .Select( role => new Claim(ClaimTypes.Role, role));

        JwtSecurityToken token = new(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims
                .Union(permissionClaims)
                .Union(roleClaims),
            expires: _dateTimeOffsetProvider.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            signingCredentials: credentials
        );

        JwtSecurityTokenHandler tokenHandler = new();
        string tokenString = tokenHandler.WriteToken(token);
        return new(tokenString);
    }
}
