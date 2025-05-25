using System.Text.Json.Serialization;

namespace Npu.Contracts.Submissions.Create;

public record class CreateSubmissionResponseDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("userId")]
    public required Guid UserId { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    
    [JsonPropertyName("imageId")]
    public Guid? ImageId { get; set; }

    [JsonPropertyName("imageName")]
    public string? ImageName { get; set; }

    [JsonPropertyName("imageUri")]
    public Uri? ImageUri { get; set; }

    
    [JsonPropertyName("partId")]
    public required Guid PartId { get; init; }

    [JsonPropertyName("brickLinkItemNumber")]
    public required string BrickLinkItemNumber { get; init; }

    [JsonPropertyName("partName")]
    public required string PartName { get; init; }


    [JsonPropertyName("createdTime")]
    public required DateTimeOffset CreatedTime { get; init; }
}