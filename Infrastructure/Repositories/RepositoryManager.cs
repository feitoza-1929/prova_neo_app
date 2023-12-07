using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private Lazy<IGenericRepository<Patient>> _patient;
    private Lazy<IGenericRepository<Doctor>> _doctor;
    private Lazy<IGenericRepository<Appointment>> _appointment;

    private readonly ApplicationDbContext _context;

    public RepositoryManager(ApplicationDbContext context)
    {
        _context = context;
        _patient = new Lazy<IGenericRepository<Patient>>(() => new GenericRepository<Patient>(context));
        _doctor = new Lazy<IGenericRepository<Doctor>>(() => new GenericRepository<Doctor>(context));
        _appointment = new Lazy<IGenericRepository<Appointment>>(() => new GenericRepository<Appointment>(context));
    }

    public IGenericRepository<Patient> Patient => _patient.Value;
    public IGenericRepository<Doctor> Doctor => _doctor.Value;
    public IGenericRepository<Appointment> Appointment => _appointment.Value;

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}