using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Services;

public abstract class GenericService<TEntity, TCreateDto, TUpdateDto>
    where TEntity : Entity
    where TCreateDto : class
    where TUpdateDto : UpdateDto
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<TEntity> _repository;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IValidator<TEntity> _validator;

    public GenericService(IMapper mapper, IGenericRepository<TEntity> repository, IRepositoryManager repositoryManager, IValidator<TEntity> validator)
    {
        _mapper = mapper;
        _repository = repository;
        _repositoryManager = repositoryManager;
        _validator = validator;
    }


    public virtual async Task<Result<TEntity>> CreateAsync(TCreateDto dto)
    {
        var validationResult = await BeforeCreateValidation(dto);

        if (validationResult.IsFailed)
            return Result.Fail(validationResult.Errors);

        var toCreate = _mapper.Map<TCreateDto, TEntity>(dto);
        await _validator.ValidateAndThrowAsync(toCreate);
        
        _repository.Create(toCreate);

        return Result.Ok();
    }

    public virtual async Task<Result> DeleteAsync(Guid id)
    {
        var toDelete = await GetAsync(id);

        if (toDelete.IsFailed)
            return Result.Fail(toDelete.Errors);

        _repository.Delete(toDelete.Value);
        await _repositoryManager.SaveAsync();
        return Result.Ok();
    }

    public virtual async Task<Result<TEntity>> GetAsync(Guid Id, bool isTrackingChanges = false)
    {
        var result = await _repository
            .FindByCondition(x => x.Id.Equals(Id), isTrackingChanges)
            .FirstOrDefaultAsync();

        if (result is null)
            return Result.Fail(new Error("Invalid request"));

        var validationResult = await BeforeGetValidation(result);

        if (validationResult.IsFailed)
            return Result.Fail(validationResult.Errors);

        return result;
    }

    public virtual async Task<Result> UpdateAsync(TUpdateDto dto)
    {
        if (dto is null)
            return Result.Fail(new Error("Invalid request"));

        var validationResult = await BeforeUpdateValidation(dto);

        if (validationResult.IsFailed)
            return Result.Fail(validationResult.Errors);

        var toUpdate = _mapper.Map<UpdateDto, TEntity>(dto);

        await _validator.ValidateAndThrowAsync(toUpdate);

        _repository.Update(toUpdate);
        await _repositoryManager.SaveAsync();

        return Result.Ok();
    }

    protected virtual Task<Result<TUpdateDto>> BeforeUpdateValidation(Result<TUpdateDto> dtoResult)
    {
        return Task.FromResult(dtoResult);
    }

    protected virtual async Task<Result<TCreateDto>> BeforeCreateValidation(Result<TCreateDto> dtoResult)
    {
        return await Task.FromResult(dtoResult);
    }

    protected virtual Task<Result<TEntity>> BeforeGetValidation(Result<TEntity> entityResult)
    {
        return Task.FromResult(entityResult);
    }
}