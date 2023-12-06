using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ValueObjects;

public class Document
{
    [Required(ErrorMessage = "Document CPF field is required")]
    public string CPF { get; set; }
    public string? RG { get; set; }
}