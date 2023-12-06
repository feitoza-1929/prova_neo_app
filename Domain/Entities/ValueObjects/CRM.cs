using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ValueObjects;

public class CRM
{
    [Required(ErrorMessage = "CRM UF field is required")]
    public string UF { get; set; }

    [Required(ErrorMessage = "CRM number field is required")]
    [MaxLength(6, ErrorMessage = "CRM number field cannot exceed 6 digits")]
    public int Number { get; set; }
}