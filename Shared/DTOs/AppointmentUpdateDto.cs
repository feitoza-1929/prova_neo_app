namespace Shared.DTOs;

public record AppointmentUpdateDto : UpdateDto
{
    public Guid? DoctorId { get; init; }
    public double? Value { get; init; }
    public AppointmentStates? States { get; init; }
    public DateTime? ScheduleAt { get; init; }

}