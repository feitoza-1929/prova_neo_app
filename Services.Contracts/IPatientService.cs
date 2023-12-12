using Domain.Entities;
using FluentResults;
using Shared;
using Shared.DTOs;

namespace Services.Contracts;

public interface IPatientService : IGenericService<Patient, PatientCreateDto, PatientUpdateDto>
{
}