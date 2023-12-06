using System.ComponentModel.DataAnnotations;
using Domain.Shared;

namespace Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Appointment value field is required")]
    [MaxLength(5, ErrorMessage = "Appointment value field cannot exceed 5 digits")]
    public double Value { get; set; }

    [Required(ErrorMessage = "Appointment state field is required")]
    public AppointmentStates State { get; set; }

    [Required(ErrorMessage = "Appointment scheduledAt field is required")]
    public DateTime ScheduledAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
}

