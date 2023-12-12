namespace Shared;

public record PatientResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Age { get; init; }
    public DocumentDto Document { get; init; }
    public Guid DoctorId { get; init; }
    public Guid UserId { get; init; }
    public DateTime CreatedAt { get; init; }
}