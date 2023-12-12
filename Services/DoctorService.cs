using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using Services.Contracts;
using Shared.DTOs;

namespace Services;

public class DoctorService : GenericService<Doctor, DoctorCreateDto, DoctorUpdateDto>, IDoctorService
{

    public DoctorService(IMapper mapper, IGenericRepository<Doctor> repository, IValidator<Doctor> validator)
    : base(mapper, repository, validator)
    { }
}
