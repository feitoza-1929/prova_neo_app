using Dapper;
using Domain.Contracts;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> FindAll(bool isTrackingChanges = false) => 
        isTrackingChanges is false
        ? _context.Set<TEntity>().AsNoTracking() 
        : _context.Set<TEntity>();

    public IQueryable<TEntity> FindByCondition(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression, bool isTrackingChanges = false) =>
        isTrackingChanges is false
        ? _context.Set<TEntity>().Where(expression).AsNoTracking()
        : _context.Set<TEntity>().Where(expression);

    public void Update(TEntity entity)
        => _context.Set<TEntity>().Update(entity);
    public void Create(TEntity entity)
        => _context.Set<TEntity>().Add(entity);

    public async Task Delete(Guid id) => 
        _context.Set<TEntity>().Remove(await _context.Set<TEntity>().FindAsync(id));

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}