using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Services.Contracts;
public interface IAuthenticationService
{
    Task<IdentityResult> CreateUserAsync(UserRegistrationDto userRegistration);
    Task<bool> ValidateUserAsync(UserAuthenticationDto userForAuth);
    Task<string> CreateTokenAsync();
}
