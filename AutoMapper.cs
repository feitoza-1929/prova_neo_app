using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using Shared;
using Shared.DTOs;

namespace ProvaNeoApp;

public class AutoMapper : Profile
{
    public AutoMapper(IServiceManager serviceManager)
    {
        CreateMap<Doctor, DoctorResponseDto>();
        CreateMap<DoctorUpdateDto, Doctor>();
        CreateMap<DoctorCreateDto, Doctor>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => serviceManager.UserVerifyService.GetUserId()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow));

        CreateMap<Patient, PatientResponseDto>();
        CreateMap<PatientUpdateDto, Patient>();
        CreateMap<PatientCreateDto, Patient>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => serviceManager.UserVerifyService.GetUserId()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow));

        CreateMap<Appointment, AppointmentResponseDto>();
        CreateMap<AppointmentUpdateDto, Appointment>();
        CreateMap<AppointmentCreateDto, Appointment>()
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow))
           .ForMember(dest => dest.State, opt => opt.MapFrom(x => AppointmentStates.SCHEDULED));

        CreateMap<UserCreateDto, User>();
    }
       
}