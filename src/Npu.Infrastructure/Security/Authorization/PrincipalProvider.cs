using Microsoft.AspNetCore.Http;
using Npu.Domain.Tokens;
using Npu.Domain.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Npu.Infrastructure.Security.Authorization;

internal class PrincipalProvider : IPrincipalProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PrincipalProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Principal GetCurrent()
    {
        try
        {
            HttpContext httpContext = _httpContextAccessor
                ?.HttpContext
                ?? throw new ArgumentNullException(nameof(HttpContext));

            IdentityId id = IdentityId.Parse(GetSingleClaimValue(httpContext, "id"));

            Identification identification = new()
            {                
                FirstName = GetSingleClaimValue(httpContext, JwtRegisteredClaimNames.Name),
                LastName = GetSingleClaimValue(httpContext, ClaimTypes.Surname),
                Email = GetSingleClaimValue(httpContext, ClaimTypes.Email)
            };

            Identity identity = new(id, identification);

            IReadOnlyCollection<Permission> permissions = [..GetClaimValues(httpContext, "permissions")
                .Select(Permission.Parse)];
            IReadOnlyCollection<Role> roles = [..GetClaimValues(httpContext, "roles")
                .Select(Role.Parse)];

            return new Principal(identity, permissions, roles);
        }
        catch (Exception exception)
        {
            string message = "Could not get current identity or principal";
            throw new PrincipalException(message, exception);
        }
    }

    private static IReadOnlyCollection<string> GetClaimValues(HttpContext httpContext, string claimType) =>
        [.. httpContext.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)];

    private static string GetSingleClaimValue(HttpContext httpContext, string claimType) =>
        httpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
}
