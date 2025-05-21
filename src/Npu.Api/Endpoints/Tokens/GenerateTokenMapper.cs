using Npu.Application.Tokens.Generate;
using Npu.Contracts.Tokens;

namespace Npu.Api.Endpoints.Tokens;

internal static class GenerateTokenMapper
{
    public static GenerateTokenCommand MapFrom(this GenerateTokenRequestDto requestDto)
        => new()
        {
            Id = requestDto.Id,
            Email = requestDto.Email,
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
            Permissions = requestDto.Permissions,
            Roles  = requestDto.Roles       
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
