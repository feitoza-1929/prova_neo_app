using System.Security.Claims;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Validations;
using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Shared;
using Shared.DTOs;

namespace Services;

public class DoctorService : GenericService<Doctor, DoctorCreateDto, DoctorUpdateDto>, IDoctorService
{

    public DoctorService(IMapper mapper, IGenericRepository<Doctor> repository, IValidator<Doctor> validator)
    : base(mapper, repository, validator)
    { }
}
