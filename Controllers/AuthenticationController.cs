using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DTOs;

namespace ProvaNeoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class  AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _service;

    public AuthenticationController(IAuthenticationService service)
    {
        _service = service;
    }

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
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreate)
    {
        var result = await _service.CreateUserAsync(userCreate);
        
        if (result.IsFailed)
            return BadRequest();

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
        var result = await _service.AuthenticateUserAsync(userAuthentication);

        if (result.IsFailed)
            return Unauthorized();
        
        return Ok(new {Token = result.Value});
    }
}