using Domain.Entities;
using Infrastructure.Context.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;


public class ApplicationDbContext : DbContext
{
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<Appointment>? Appointments { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
    }
}