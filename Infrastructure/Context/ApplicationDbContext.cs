using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Infrastructure.Context.Configuration;

namespace Infrastructure.Context;


public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<Appointment>? Appointments { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}