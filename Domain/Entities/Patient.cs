using Domain.Entities.ValueObjects;

namespace Domain.Entities;

public class Patient : Entity
{
    public string Name { get; set; }
    public int Age { get; set;}
    public Document Document {get; set;}
    public ICollection<Appointment> Appointments { get; set; }
}