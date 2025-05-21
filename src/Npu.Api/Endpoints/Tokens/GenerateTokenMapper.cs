using Npu.Application.Tokens.Generate;
using Npu.Contracts.Tokens;
using Npu.Domain.Tokens;

namespace Npu.Api.Endpoints.Tokens;

internal static class GenerateTokenMapper
{
    public static GenerateTokenCommand MapFrom(this GenerateTokenRequestDto requestDto)
        => new()
        {
            TokenId = new TokenId(requestDto.Id ?? Guid.CreateVersion7()),
            Identification = new()
            { 
                Email = requestDto.Email,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName
            },
            Permissions = [..requestDto.Permissions.Select( s => new Permission( s ) )],
            Roles = [.. requestDto.Roles.Select(s => new Role(s))],            
        };

    public static GenerateTokenResponseDto MapTo(this GenerateTokenCommandResult commandResult) =>
        new()
        {
            Id = commandResult.TokenId,
            Token = commandResult.Token,
            FirstName = commandResult.Identification.FirstName,
            LastName = commandResult.Identification.LastName,
            Email = commandResult.Identification.Email
        };
}
