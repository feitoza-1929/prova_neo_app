using Microsoft.AspNetCore.Identity;

namespace Services.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
}
