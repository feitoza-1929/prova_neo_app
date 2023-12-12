using Microsoft.AspNetCore.Identity;

namespace Services.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
    IUserVerifyService UserVerifyService { get; }
    IAppointmentService AppointmentService { get; }
    IPatientService PatientService { get; }
    IDoctorService DoctorService { get; }
}
