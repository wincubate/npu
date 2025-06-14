﻿using Npu.Application.Votes.Create;
using Npu.Contracts.Votes.Create;

namespace Npu.Api.Endpoints.Votes.Create;

internal static class CreateVoteMapper
{
    public static CreateVoteCommand MapFrom(this CreateVoteRequestDto requestDto,
        Guid userId, 
        Guid submissionId
    )
        => new()
        {
            UserId = new(userId),
            SubmissionId = submissionId,
            CreativityScore = requestDto.CreativityScore,
            UniquenessScore = requestDto.UniquenessScore
        };

    public static (Uri resource, CreateVoteResponseDto) MapTo(this CreateVoteCommandResult commandResult)
    {
        Uri resource = new(
            $"https://localhost:7044/submissions/{commandResult.Vote.SubmissionId}/votes/{commandResult.Vote.Id}"
        );
        
        CreateVoteResponseDto responseDto =  new()
        {
            Id = commandResult.Vote.Id,
            UserId = commandResult.Vote.UserId,                        
            CreatedTime = commandResult.CreatedTime,
        };

        return (resource, responseDto);
    }
}
