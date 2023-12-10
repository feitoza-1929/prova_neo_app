using AutoMapper;
using Domain.Entities;
using Shared.DTOs;

namespace ProvaNeoApp;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<UserRegistrationDto, User>();
    }
}