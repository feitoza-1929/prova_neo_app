using Domain.Entities.ValueObjects;

namespace Domain.Entities;

public class Doctor : Entity
{
    public CRM CRM { get; set; }
    public string Name { get; set; }
    public Document Document { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}
