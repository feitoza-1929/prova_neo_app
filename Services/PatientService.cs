using System.Security.Claims;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Shared;

namespace Services;

public class PatientService : GenericService<Patient, PatientCreateDto, PatientUpdateDto>,IPatientService
{
    public PatientService(IMapper mapper, IGenericRepository<Patient> repository, IValidator<Patient> validator)
        : base(mapper, repository, validator)
    { }
}