using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class  AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthenticationController(IServiceManager service)
        => _service = service;
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserRegistrationDto userRegistration)
    {
        var result = await _service.AuthenticationService.CreateUserAsync(userRegistration);
        
        if(!result.Succeeded)
        {
            result.Errors.All(error =>
            {
                ModelState.TryAddModelError(error.Code, error.Description);
                return true;
            });
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUserAsync(user))
            return Unauthorized();

        return Ok(new {Token = await _service.AuthenticationService.CreateTokenAsync()});
    }
}