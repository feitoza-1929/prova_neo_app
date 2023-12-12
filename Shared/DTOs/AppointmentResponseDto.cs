using Shared;

public record AppointmentResponseDto
{
    public double Value { get; init; }
    public AppointmentStates State { get; init; }
    public DateTime ScheduledAt { get; init; }
    public DateTime CreatedAt { get; init; }
    public Guid DoctorId { get; init; }
    public Guid PatientId { get; init; }
}