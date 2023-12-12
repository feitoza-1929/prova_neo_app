using System.Runtime.InteropServices;
using System.Security.Claims;
using Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Services.Contracts;

namespace Services;

public class UserVerifyService : IUserVerifyService
{
    private IHttpContextAccessor _httpContextAcessor;
    public UserVerifyService(IHttpContextAccessor httpContextAccessor) => _httpContextAcessor = httpContextAccessor;
    public bool IsUserValid(Guid id)
    {
        return id.Equals(GetUserId());
    }

    public Guid GetUserId()
    {
        return Guid.Parse(_httpContextAcessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}