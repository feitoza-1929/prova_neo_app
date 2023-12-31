using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using Services.Contracts;
using Shared;
using Shared.DTOs;

namespace ProvaNeoApp;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Doctor, DoctorResponseDto>();
        CreateMap<DoctorUpdateDto, Doctor>();
        CreateMap<DoctorCreateDto, Doctor>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow));

        CreateMap<Patient, PatientResponseDto>();
        CreateMap<PatientUpdateDto, Patient>();
        CreateMap<PatientCreateDto, Patient>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow));

        CreateMap<DocumentDto, Document>()
            .ReverseMap();

        CreateMap<Appointment, AppointmentResponseDto>();
        CreateMap<AppointmentUpdateDto, Appointment>();
        CreateMap<AppointmentCreateDto, Appointment>()
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow))
           .ForMember(dest => dest.State, opt => opt.MapFrom(x => AppointmentStates.SCHEDULED));

        CreateMap<UserCreateDto, User>();
    }
       
}