using System.ComponentModel.DataAnnotations;
using Domain.Entities.ValueObjects;

namespace Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Doctor CRM field is required")]
    public CRM CRM { get; set; }
    
    [Required(ErrorMessage = "Doctor name field is required")]
    [MaxLength(50, ErrorMessage = "Doctor name field cannot exceed 6 digits")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Doctor document field is required")]
    public Document Document { get; set; }
    
    public ICollection<Appointment> Appointments { get; set; }
}
