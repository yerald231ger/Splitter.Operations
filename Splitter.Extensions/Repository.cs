

using Microsoft.EntityFrameworkCore;

namespace Splitter.Extensions;

public abstract class Repository<TEntity, TKey>(DbContext dbContext) : IRepository<TEntity, TKey> where TEntity : class
{
    protected DbContext Context { get; } = dbContext;
    private readonly DbSet<TEntity> _entities = dbContext.Set<TEntity>();

    public async Task<int> AddAsync(TEntity entity)
    {
    
        var result = await _entities.AddAsync(entity);
        var exit = await Context.SaveChangesAsync();
        result.State = EntityState.Detached;
        return exit;
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        return await Context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAsync()
    {
        return await Task.FromResult(Context.Set<TEntity>().ToList());
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var result = await Context.Set<TEntity>().FindAsync(id);
        return result;
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        return await Context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> Filter(Func<TEntity, bool> predicate)
    {
        return await Task.FromResult(Context.Set<TEntity>().Where(predicate).ToList());
    }
}