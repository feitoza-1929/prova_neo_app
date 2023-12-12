using System.ComponentModel.DataAnnotations;
using Shared;

namespace Domain.Entities;

public class Appointment : Entity
{
    public double Value { get; set; }
    public AppointmentStates State { get; set; }
    public DateTime ScheduledAt { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
}

