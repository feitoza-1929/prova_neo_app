using System.Linq.Expressions;

namespace Domain.Contracts;

public interface IGenericRepository<TEntity>
{
    IQueryable<TEntity> FindAll(bool isTrackingChanges = false);
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool isTrackingChanges = false);
    void Create(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    Task SaveAsync();
}