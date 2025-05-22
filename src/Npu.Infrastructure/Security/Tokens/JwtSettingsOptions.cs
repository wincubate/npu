namespace Npu.Infrastructure.Security.Tokens;

public record class JwtSettingsOptions
{
    public required string Audience { get; init; }
    public required string Issuer { get; init; }
    public required string Secret { get; init; }
    public int TokenExpirationInMinutes { get; init; } = 60;
}
