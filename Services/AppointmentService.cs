using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using Services.Contracts;
using Shared.DTOs;

namespace Services;

public class AppointmentService : GenericService<Appointment, AppointmentCreateDto, AppointmentUpdateDto>, IAppointmentService
{
    public AppointmentService(IMapper mapper, IGenericRepository<Appointment> repository, IValidator<Appointment> validator)
    : base(mapper, repository, validator)
    {
    }
}