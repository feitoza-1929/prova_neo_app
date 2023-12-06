using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Doctor
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Doctor CRM field is required")]
    public CRM CRM { get; set; }
    
    [Required(ErrorMessage = "Doctor name field is required")]
    [MaxLength(50, ErrorMessage = "Doctor name field cannot exceed 6 digits")]
    public string Name { get; set; }
}
