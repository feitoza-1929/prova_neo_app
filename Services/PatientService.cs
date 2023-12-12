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
    private readonly IServiceManager _serviceManager;

    public PatientService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Patient> validator, IServiceManager serviceManager)
    : base(mapper, repositoryManager.Patient, repositoryManager, validator)
    {
        _serviceManager = serviceManager;
    }

    protected override Task<Result<PatientUpdateDto>> BeforeUpdateValidation(Result<PatientUpdateDto> dtoResult)
    {
        if(_serviceManager.UserVerifyService.IsUserValid(dtoResult.Value.UserId))
            return base.BeforeUpdateValidation(dtoResult);

        return base.BeforeUpdateValidation(Result.Fail("Invalid request"));  
    }

    protected override Task<Result<Patient>> BeforeGetValidation(Result<Patient> entityResult)
    {
        if(_serviceManager.UserVerifyService.IsUserValid(entityResult.Value.UserId))
            return base.BeforeGetValidation(entityResult);

        return base.BeforeGetValidation(Result.Fail("Invalid request"));
    }
}