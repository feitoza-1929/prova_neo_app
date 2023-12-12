using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthenticationService> _authenticationService;
    private Lazy<IUserVerifyService> _userVerifyService;
    private Lazy<IAppointmentService> _appointmentService;
    private Lazy<IPatientService> _patientService;
    private Lazy<IDoctorService> _doctorService;


    public ServiceManager(
        IMapper mapper,
        IConfiguration configuration,
        UserManager<User> userManager, 
        IRepositoryManager repositoryManager, 
        IValidator<Appointment> appointmentValidator,
        IValidator<Patient> patientValidator,
        IValidator<Doctor> doctorValidator,
        IHttpContextAccessor httpContextAccessor)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
        _userVerifyService = new Lazy<IUserVerifyService>(() => new UserVerifyService(httpContextAccessor));

        _appointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(mapper, repositoryManager, appointmentValidator, this));
        _patientService = new Lazy<IPatientService>(() => new PatientService(mapper, repositoryManager, patientValidator, this));
        _doctorService = new Lazy<IDoctorService>(() => new DoctorService(mapper, repositoryManager, doctorValidator, this));
        
    }
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IUserVerifyService UserVerifyService => _userVerifyService.Value;
    public IAppointmentService AppointmentService => _appointmentService.Value;
    public IPatientService PatientService => _patientService.Value;
    public IDoctorService DoctorService => _doctorService.Value;
}
