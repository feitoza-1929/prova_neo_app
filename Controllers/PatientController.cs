using AutoMapper;
using Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared;
using Shared.DTOs;


namespace ProvaNeoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _service;
    private readonly IMapper _mapper;

    public PatientController(IPatientService service, IMapper mapper)
    { 
        _service = service;
        _mapper = mapper;
    }


    /// <summary>
    /// Retorna um paciente especificado pelo id
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     GET api/patient/448a2109-b47c-4aa9-87f8-6b52878e84f5
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Retorna paciente</response>
    /// <response code="400">Dados invalidos</response>        
    [HttpGet("{id}")]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _service.GetAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(_mapper.Map<Patient, PatientResponseDto>(result.Value));
    }

    /// <summary>
    /// Cria um paciente
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     POST api/patient
    ///     {
    ///        "name": "Jesse Faden",
    ///        "age": 28,
    ///        "document": {
    ///             "cpf": "000.000.000-00",
    ///             "rg": "000000"
    ///        }
    ///     }
    ///
    /// </remarks>
    /// <param name="patientCreate"></param>
    /// <returns></returns>
    /// <response code="200">Paciente criado</response>
    /// <response code="400">Dados invalidos</response>        
    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Create([FromBody] PatientCreateDto patientCreate)
    {
        var result = await _service.CreateAsync(patientCreate);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(new { result.Value.Id });
    }

    /// <summary>
    /// Atualiza dados do paciente
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     PUT api/patient
    ///     {
    ///        "id": "448a2109-b47c-4aa9-87f8-6b52878e84f5",
    ///         "name": "Dylan Faden",
    ///        "age": 27,
    ///        "document": {
    ///             "cpf": "000.000.000-00",
    ///             "rg": "000000"
    ///        }
    ///     }
    ///
    /// </remarks>
    /// <param name="patientUpdate"></param>
    /// <returns></returns>
    /// <response code="200">Paciente atualizado</response>
    /// <response code="400">Dados invalidos</response>      
    [HttpPut]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Update([FromBody] PatientUpdateDto patientUpdate)
    {
        var result = await _service.UpdateAsync(patientUpdate);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }

    /// <summary>
    /// Deleta um paciente especificado pelo id
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     DELETE api/patient/448a2109-b47c-4aa9-87f8-6b52878e84f5
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Paciente deletado</response>
    /// <response code="400">Dados invalidos</response>      
    [HttpDelete("{id}")]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }
}