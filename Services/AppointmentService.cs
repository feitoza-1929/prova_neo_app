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
    private readonly IServiceManager _serviceManage;

    public AppointmentService(IMapper mapper, IRepositoryManager repositoryManager, IValidator<Appointment> validator, IServiceManager serviceManager)
    : base(mapper, repositoryManager.Appointment, repositoryManager, validator)
    {
        _serviceManage = serviceManager;
    }

    protected override Task<Result<Appointment>> BeforeGetValidation(Result<Appointment> entityResult)
    {
        if(_serviceManage.UserVerifyService.IsUserValid(entityResult.Value.DoctorId) 
        || _serviceManage.UserVerifyService.IsUserValid(entityResult.Value.PatientId))
            return base.BeforeGetValidation(entityResult);

        return base.BeforeGetValidation(Result.Fail("Invalid request"));
    }

    protected override Task<Result<AppointmentUpdateDto>> BeforeUpdateValidation(Result<AppointmentUpdateDto> dtoResult)
    {
        if(_serviceManage.UserVerifyService.IsUserValid(dtoResult.Value.UserId))
            return base.BeforeUpdateValidation(dtoResult);

        return base.BeforeUpdateValidation(Result.Fail("Invalid request"));
    }
}