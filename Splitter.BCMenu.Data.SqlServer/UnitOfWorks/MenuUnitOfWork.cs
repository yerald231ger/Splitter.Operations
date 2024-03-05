using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Splitter.BCMenu.Infrastructure;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class MenuUnitOfWork(
    MenuDbContext context,
    IMenuRepository menuRepository) : IMenuUnitOfWork
{
    public IMenuRepository MenuRepository { get; } = menuRepository;
    private readonly MenuDbContext _context = context;

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public Task<Guid> UpdateMenu(Menu menu)
    {
        MenuRepository.UpdateAsync(menu);
        return Task.FromResult(menu.Id);
    }

    public async Task<Menu?> GetCompleteMenu(Guid menuId)
    {
        var menus = from m in _context.Menus
                   where m.Id == menuId
                   join c in _context.Categories on m.Id equals c.MenuId
                   join p in _context.Products on m.Id equals p.MenuId
                   join ml in _context.MenuLayouts on m.Id equals ml.MenuId
                   select m;

        if(menus == null || !menus.Any())
            return default;

        return await menus.FirstAsync();
    }
}
