using AutoMapper;
using Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DTOs;


namespace ProvaNeoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _service;
    private readonly IMapper _mapper;

    public AppointmentController(IAppointmentService service, IMapper mapper)
    { 
        _service = service;
        _mapper = mapper;
    }


    /// <summary>
    /// Retorna uma consulta médica especificada pelo id
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     GET api/appointment/448a2109-b47c-4aa9-87f8-6b52878e84f5
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Retorna consulta médica</response>
    /// <response code="400">Dados invalidos</response>        
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _service.GetAsync(id);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(_mapper.Map<Appointment, AppointmentResponseDto>(result.Value));
    }

    /// <summary>
    /// Cria uma consulta médica
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     POST api/appointment
    ///     {
    ///        "patientId": "448a2109-b47c-4aa9-87f8-6b52878e84f5",
    ///        "doctorId": "54c5ca28-4528-4ce2-b7c3-f3a05ac1d941",
    ///        "value": 50,
    ///        "scheduleAt": 2023-12-29 16:30:00
    ///     }
    ///
    /// </remarks>
    /// <param name="appointmentCreation"></param>
    /// <returns></returns>
    /// <response code="200">Consulta médica criada</response>
    /// <response code="400">Dados invalidos</response>        
    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Create([FromBody] AppointmentCreateDto appointmentCreation)
    {
        var result = await _service.CreateAsync(appointmentCreation);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(new { Id = result.Value });
    }

    /// <summary>
    /// Atualiza dados da consulta médica
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     PUT api/appointment
    ///     {
    ///        "id": "448a2109-b47c-4aa9-87f8-6b52878e84f5",
    ///        "doctorId": "54c5ca28-4528-4ce2-b7c3-f3a05ac1d941",
    ///        "value": 50,
    ///        "states": 2,
    ///        "scheduleAt": 2023-12-29 16:30:00
    ///     }
    ///
    /// </remarks>
    /// <param name="appointmentUpdate"></param>
    /// <returns></returns>
    /// <response code="200">Consulta médica atualizada</response>
    /// <response code="400">Dados invalidos</response>      
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] AppointmentUpdateDto appointmentUpdate)
    {
        var result = await _service.UpdateAsync(appointmentUpdate);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }

    /// <summary>
    /// Deleta uma consulta médica especificada pelo id
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     DELETE api/appointment/448a2109-b47c-4aa9-87f8-6b52878e84f5
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Consulta médica deletada</response>
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