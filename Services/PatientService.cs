using AutoMapper;
using Dapper;
using Domain.Contracts;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Shared;

namespace Services;

public class PatientService : GenericService<Patient, PatientCreateDto, PatientUpdateDto>,IPatientService
{
    private readonly ISqlConnectionFactory _connectionFactory;
    public PatientService(IMapper mapper, IGenericRepository<Patient> repository, IValidator<Patient> validator, ISqlConnectionFactory connectionFactory)
        : base(mapper, repository, validator)
    { 
        _connectionFactory = connectionFactory;
    }

    public override async Task<Result> DeleteAsync(Guid id)
    {
        using SqlConnection connection = _connectionFactory.Create();
        await connection.ExecuteAsync("DELETE FROM Patients WHERE Id = @Id", new { Id = id });
        return Result.Ok();
    }
}