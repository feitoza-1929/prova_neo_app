using Domain.Contracts;
using Domain.Entities;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Context;
using Infrastructure.Dapper;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Contracts;


namespace ProvaNeoApp.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IGenericRepository<Appointment>, GenericRepository<Appointment>>();
        services.AddTransient<IGenericRepository<Doctor>, GenericRepository<Doctor>>();
        services.AddTransient<IGenericRepository<Patient>, GenericRepository<Patient>>();
        services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
    }
    
    public static void AddSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
    }

    public static void AddDomainValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Appointment>, AppointmentValidator>();
        services.AddScoped<IValidator<Patient>, PatientValidator>();
        services.AddScoped<IValidator<Doctor>, DoctorValidator>();
    }
}