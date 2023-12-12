namespace Shared;

public record PatientCreateDto
{
    public string Name { get; init; }
    public int Age { get; init; }
    public DocumentDto Document { get; init; }
}