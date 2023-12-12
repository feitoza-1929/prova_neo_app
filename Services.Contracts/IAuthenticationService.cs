using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Services.Contracts;
public interface IAuthenticationService
{
    Task<IdentityResult> CreateUserAsync(UserCreateDto userRegistration);
    Task<bool> ValidateUserAsync(UserAuthenticationDto userForAuth);
    Task<string> CreateTokenAsync();
}
