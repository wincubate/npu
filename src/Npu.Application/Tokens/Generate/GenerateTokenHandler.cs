using MediatR;
using Npu.Application.Common.Security.Permissions;
using Npu.Application.Common.Security.Roles;
using Npu.Application.Common.Security.Tokens;
using Npu.Domain.Users;

namespace Npu.Application.Tokens.Generate;

internal class GenerateTokenHandler
    : IRequestHandler<GenerateTokenCommand, GenerateTokenCommandResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public GenerateTokenHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<GenerateTokenCommandResult> Handle(GenerateTokenCommand command, CancellationToken cancellationToken)
    {
        TokenId tokenId = command.Id switch
        {
            Guid id => new TokenId(id),
            _ => TokenId.New()
        };

        Identification identification = new()
        {
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName
        };

        Permission[] permissions = [.. command.Permissions.Select(s => new Permission(s))];
        Role[] roles = [.. command.Roles.Select(s => new Role(s))];

        Token generatedToken = _jwtTokenGenerator.GenerateToken(
            tokenId,
            identification,
            permissions,
            roles
        );

        return Task.FromResult(
            new GenerateTokenCommandResult()
            {
                TokenId = tokenId,
                Token = generatedToken,
                Identification = identification
            }
        );
    }
}