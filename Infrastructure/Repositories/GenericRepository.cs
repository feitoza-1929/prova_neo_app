using Dapper;
using Domain.Contracts;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly ISqlConnectionFactory _connectionFactory;

    public GenericRepository(ApplicationDbContext context, ISqlConnectionFactory connectionFactory)
    {
        _context = context;
        _connectionFactory = connectionFactory;
    }

    public IQueryable<TEntity> FindAll(bool isTrackingChanges = false) => 
        isTrackingChanges is false
        ? _context.Set<TEntity>().AsNoTracking() 
        : _context.Set<TEntity>();

    public IQueryable<TEntity> FindByCondition(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression, bool isTrackingChanges = false) =>
        isTrackingChanges is false
        ? _context.Set<TEntity>().Where(expression).AsNoTracking()
        : _context.Set<TEntity>().Where(expression);

    public IEnumerable<TEntity> FindById(Guid id, string entityName) 
    {
        using SqlConnection connection = _connectionFactory.Create();
        
        var result = connection.Query<TEntity>($"SELECT * FROM {entityName} WHERE Id = @id", new { id });
        
        return result;
    }
    public void Update(TEntity entity)
        => _context.Set<TEntity>().Update(entity);
    public void Create(TEntity entity)
        => _context.Set<TEntity>().Add(entity);

    public async Task Delete(Guid id)
    {
        using SqlConnection connection = _connectionFactory.Create();
        var sql = $"DELETE {nameof(TEntity)} WHERE Id = @Id";
        await connection.ExecuteAsync(sql, new { id });
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}