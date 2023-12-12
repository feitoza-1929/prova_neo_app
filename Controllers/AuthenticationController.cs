using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DTOs;

namespace ProvaNeoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class  AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthenticationController(IServiceManager service)
        => _service = service;

    /// <summary>
    /// Cria usuário com determinado niveis de acesso a recursos na API
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     POST api/authentication
    ///     {
    ///        "userName": "Jesse Faden",
    ///        "password": 1234567890,
    ///        "roles": ["Patient"]
    ///     }
    ///
    /// </remarks>
    /// <param name="userRegistration"></param>
    /// <returns></returns>
    /// <response code="201">Usuário criado</response>
    /// <response code="400">Dados Invalidos</response>        
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userRegistration)
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

    /// <summary>
    /// Valida nome e senha de usuário, permitindo acesso a os demais recursos da API
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     POST api/authentication/login
    ///     {
    ///        "userName": "Jesse Faden",
    ///        "password": 1234567890,
    ///     }
    ///
    /// </remarks>
    /// <param name="userAuthentication"></param>
    /// <returns>Retorna token</returns>
    /// <response code="200">Usuário validado</response>
    /// <response code="401">Usuário inexistente/dados invalidos</response>        
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto userAuthentication)
    {
        if (!await _service.AuthenticationService.ValidateUserAsync(userAuthentication))
            return Unauthorized();

        return Ok(new {Token = await _service.AuthenticationService.CreateTokenAsync()});
    }
}