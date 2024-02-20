using System.Linq.Expressions;

namespace Splitter.Operations.Infrastructure;

public interface IRepository<TEntity,Tkey> where TEntity : class
{   
    Task<TEntity?> GetByIdAsync(Tkey id);
    Task<List<TEntity>> GetAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
    Task<TEntity?> Filter(Expression<Func<TEntity, bool>> predicate);

}
