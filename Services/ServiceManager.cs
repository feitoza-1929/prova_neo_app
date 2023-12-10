using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() => 
            new AuthenticationService(mapper, userManager, configuration));
    }
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
