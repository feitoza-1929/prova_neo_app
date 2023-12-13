namespace Shared.DTOs;

public record DoctorUpdateDto : UpdateDto
{
    public CRMDto? CRM { get; init; }
    public string? Name { get; init; }
    public DocumentDto? Document { get; init; }
}