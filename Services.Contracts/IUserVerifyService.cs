using Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Services.Contracts;
public interface IUserVerifyService
{
    bool IsUserValid(Guid id);
    Guid GetUserId();
}
