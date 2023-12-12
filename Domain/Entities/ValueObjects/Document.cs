using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ValueObjects;

public class Document
{
    public string CPF { get; set; }
    public string? RG { get; set; }
}