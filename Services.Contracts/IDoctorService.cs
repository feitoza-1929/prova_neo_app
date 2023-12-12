using Domain.Entities;
using FluentResults;
using Shared;
using Shared.DTOs;

namespace Services.Contracts;

public interface IDoctorService : IGenericService<Doctor, DoctorCreateDto, DoctorUpdateDto> { }