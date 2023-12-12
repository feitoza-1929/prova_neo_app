using AutoMapper;
using Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared;
using Shared.DTOs;


namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IMapper _mapper;

    public DoctorController(IServiceManager service, IMapper mapper)
    { 
        _service = service;
        _mapper = mapper;
    }


    /// <summary>
    /// Retorna um médico em especificado pelo id
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     GET api/doctor/448a2109-b47c-4aa9-87f8-6b52878e84f5
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Retorna médico</response>
    /// <response code="400">Dados invalidos</response>        
    [HttpGet("{id}")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> Get([FromQuery] Guid id)
    {
        var result = await _service.DoctorService.GetAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(_mapper.Map<Doctor, DoctorResponseDto>(result.Value));
    }

    /// <summary>
    /// Cria um médico
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     POST api/doctor
    ///     {
    ///        "name": "Casper Darling",
    ///        "crm": {
    ///             "uf": NY,
    ///             "number": 000001
    ///        },
    ///        "document": {
    ///             "cpf": "000.000.000-00",
    ///             "rg": "000000"
    ///        }
    ///     }
    ///
    /// </remarks>
    /// <param name="doctorCreate"></param>
    /// <returns></returns>
    /// <response code="200">Médico criado</response>
    /// <response code="400">Dados invalidos</response>        
    [HttpPost]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> Create([FromBody] DoctorCreateDto doctorCreate)
    {
        var result = await _service.DoctorService.CreateAsync(doctorCreate);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(new { result.Value.Id });
    }

    /// <summary>
    /// Atualiza dados do médico
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     PUT api/doctor
    ///     {
    ///        "id": "448a2109-b47c-4aa9-87f8-6b52878e84f5",
    ///        "name": "Casper Darling",
    ///        "crm": {
    ///             "uf": SP,
    ///             "number": 000001
    ///        },
    ///        "document": {
    ///             "cpf": "000.000.000-00",
    ///             "rg": "000000"
    ///        }
    ///     }
    ///
    /// </remarks>
    /// <param name="doctorUpdate"></param>
    /// <returns></returns>
    /// <response code="200">Médico atualizado</response>
    /// <response code="400">Dados invalidos</response>      
    [HttpPut]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> Update([FromBody] DoctorUpdateDto doctorUpdate)
    {
        var result = await _service.DoctorService.UpdateAsync(doctorUpdate);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }

    /// <summary>
    /// Deleta um médico especificado pelo id
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     DELETE api/doctor/448a2109-b47c-4aa9-87f8-6b52878e84f5
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Médico deletado</response>
    /// <response code="400">Dados invalidos</response>      
    [HttpDelete("{id}")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var result = await _service.DoctorService.DeleteAsync(id);
        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }
}