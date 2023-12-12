using Shared.DTOs;

namespace Shared;

public record DoctorResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DocumentDto Document { get; init; }
    public CRMDto CRM { get; set; }
    public Guid UserId { get; init; }
    public DateTime CreatedAt { get; init; }
}