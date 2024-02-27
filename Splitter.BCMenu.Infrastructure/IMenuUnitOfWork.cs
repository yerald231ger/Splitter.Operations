using Splitter.Extensions;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Infrastructure;

public interface IMenuUnitOfWork : IUnitOfWork
{
    public IMenuRepository MenuRepository { get; }

    
    Task<Guid> UpdateMenu(Menu commensality);
}
