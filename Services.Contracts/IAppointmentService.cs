using Domain.Entities;
using FluentResults;
using Shared.DTOs;

namespace Services.Contracts;

public interface IAppointmentService : IGenericService<Appointment, AppointmentCreateDto, AppointmentUpdateDto>
{
}