using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;

namespace Splitter.Operations.Data.SqlServer;

public abstract class Repository<TEntity, TKey>(DbContext dbContext) : IRepository<TEntity, TKey> where TEntity : class
{
    protected DbContext Context { get; } = dbContext;
    private readonly DbSet<TEntity> _entities = dbContext.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await _entities.AddAsync(entity);
        var exit = await Context.SaveChangesAsync();
        result.State = EntityState.Detached;
        return result.Entity;
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        return await Task.FromResult(1);
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
}
