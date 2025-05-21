using ErrorOr;
using MediatR;
using Npu.Application.Common.Interfaces.Tokens;
using Npu.Domain.Tokens;

namespace Npu.Application.Tokens.Generate;

internal class GenerateTokenHandler
    : IRequestHandler<GenerateTokenCommand, ErrorOr<GenerateTokenCommandResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public GenerateTokenHandler(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<ErrorOr<GenerateTokenCommandResult>> Handle(GenerateTokenCommand command, CancellationToken cancellationToken)
    {
        TokenId tokenId = command.TokenId ?? TokenId.New();
        Token generatedToken = _jwtTokenGenerator.GenerateToken(
            tokenId,
            command.Identification,
            command.Permissions,
            command.Roles
        );

        return Task.FromResult(
            ErrorOrFactory.From( 
                new GenerateTokenCommandResult()
                {
                    TokenId = tokenId,
                    Token = generatedToken,
                    Identification = command.Identification
                }
            )
        );
    }
}