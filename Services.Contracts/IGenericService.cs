using Domain.Entities;
using FluentResults;
using Shared;

namespace Services.Contracts;

public interface IGenericService<TEntity, TCreateDto, TUpdateDto>
    where TEntity : Entity
    where TCreateDto : class
    where TUpdateDto : UpdateDto
{
    Task<Result<Guid>> CreateAsync(TCreateDto dto);
    Task<Result<TEntity>> GetAsync(Guid Id, bool isTrackingChanges = false);
    Task<Result> UpdateAsync(TUpdateDto dto);
    Task<Result> DeleteAsync(Guid id);
}