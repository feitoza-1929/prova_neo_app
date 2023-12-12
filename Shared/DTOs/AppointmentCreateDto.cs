namespace Shared.DTOs;

public record AppointmentCreateDto
{
    public Guid PatientId { get; init; }
    public Guid DoctorId { get; init; }
    public double Value { get; init; }
    public DateTime ScheduleAt { get; init; }
}