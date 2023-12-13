namespace Shared;

public record PatientUpdateDto : UpdateDto
{
    public string? Name { get; init; }
    public string? Age { get; init; }
    public DocumentDto? Document { get; init; }
}