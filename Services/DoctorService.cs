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
    private readonly IServiceManager _serviceManager;

    public DoctorService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Doctor> validator, IServiceManager serviceManager)
    : base(mapper, repositoryManager.Doctor, repositoryManager, validator)
    {
        _serviceManager = serviceManager;
    }

    protected override Task<Result<DoctorUpdateDto>> BeforeUpdateValidation(Result<DoctorUpdateDto> dtoResult)
    {
        if (_serviceManager.UserVerifyService.IsUserValid(dtoResult.Value.UserId))
            return base.BeforeUpdateValidation(dtoResult);

        return base.BeforeUpdateValidation(Result.Fail("Invalid request"));
    }

    protected override Task<Result<Doctor>> BeforeGetValidation(Result<Doctor> entityResult)
    {
        if (_serviceManager.UserVerifyService.IsUserValid(entityResult.Value.Id))
            return base.BeforeGetValidation(entityResult);

        return base.BeforeGetValidation(Result.Fail("Invalid request"));
    }
}