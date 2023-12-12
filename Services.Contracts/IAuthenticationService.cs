using FluentResults;
using Shared.DTOs;

namespace Services.Contracts;
public interface IAuthenticationService
{
    Task<Result> CreateUserAsync(UserCreateDto userCreate);
    Task<Result<string>> AuthenticateUserAsync(UserAuthenticationDto userAuth);
}