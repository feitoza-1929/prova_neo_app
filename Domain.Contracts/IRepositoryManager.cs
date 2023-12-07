using Domain.Entities;

namespace Domain.Contracts;

public interface IRepositoryManager
{
    IGenericRepository<Patient> Patient { get; }
    IGenericRepository<Doctor> Doctor { get; }
    IGenericRepository<Appointment> Appointment { get; }
    Task SaveAsync();
}