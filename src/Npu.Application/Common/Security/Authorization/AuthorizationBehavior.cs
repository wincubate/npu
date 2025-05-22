using MediatR;
using Npu.Application.Common.Security.Permissions;
using Npu.Application.Common.Security.Policies;
using Npu.Application.Common.Security.Requests;
using Npu.Application.Common.Security.Roles;
using System.Reflection;

namespace Npu.Application.Common.Security.Authorization;

public class AuthorizationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IAuthorizableRequest<TResponse>
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationBehavior(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        List<AuthorizeAttribute> authorizationAttributes = [.. request
            .GetType()
            .GetCustomAttributes<AuthorizeAttribute>()
        ];

        if (authorizationAttributes.Count == 0)
        {
            return await next(cancellationToken);
        }

        IReadOnlyCollection<Permission> requiredPermissions = [.. authorizationAttributes
            .SelectMany(authorizationAttribute => authorizationAttribute
                .Permissions
                ?.Split(',')
                ?? []
            )
            .Select( Permission.Parse )
        ];
        IReadOnlyCollection<Role> requiredRoles = [.. authorizationAttributes
            .SelectMany(authorizationAttribute => authorizationAttribute
                .Roles
                ?.Split(',')
                ?? []
            )
            .Select( Role.Parse )
        ];
        IReadOnlyCollection<PolicyName> requiredPolicies = [.. authorizationAttributes
            .SelectMany(authorizationAttribute => authorizationAttribute
                .Policies
                ?.Split(',')
                ?? []
            )
            .Select(PolicyName.Parse)
        ];

        AuthorizationRequirements requirements = new()
        {
            Permissions = requiredPermissions,
            Roles = requiredRoles,
            Policies = requiredPolicies
        };

        _authorizationService.Authorize(request, requirements);

        return await next(cancellationToken);
    }
}