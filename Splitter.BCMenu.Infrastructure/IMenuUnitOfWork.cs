using Splitter.Extensions;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Infrastructure;

public interface IMenuUnitOfWork : IUnitOfWork
{
    public IMenuRepository MenuRepository { get; }

    Task<Menu?> GetCompleteMenu(Guid menuId);
    Task<Menu?> GetMenuBuildedLayout(Guid menuId);

    Task<Guid> UpdateMenu(Menu menu);
}
