using System.ComponentModel.DataAnnotations;
using Domain.Entities.ValueObjects;

namespace Domain.Entities;

public class Patient
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Patient name field is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Patient age field is required")]
    [MaxLength(3, ErrorMessage = "Patient age field cannot exceed 3 digits")]
    public int Age { get; set;}

    [Required(ErrorMessage = "Patient document field is required")]
    public Document Document {get; set;}

    public ICollection<Appointment> Appointments { get; set; }
}