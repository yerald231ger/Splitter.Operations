namespace Splitter.Extensions;

public interface IRepository<TEntity,Tkey> where TEntity : class
{   
    Task<TEntity?> GetByIdAsync(Tkey id);
    Task<List<TEntity>> GetAsync();
    Task<int> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
    Task<List<TEntity>> Filter(Func<TEntity, bool> predicate);
}