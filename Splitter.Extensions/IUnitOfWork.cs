namespace Splitter.Extensions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
