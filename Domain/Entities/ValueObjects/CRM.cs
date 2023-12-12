using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ValueObjects;

public class CRM
{
    public string UF { get; set; }
    public int Number { get; set; }
}