using System.IO.Compression;
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

    public async Task<Guid> UpdateMenu(Menu menu)
    {
        await MenuRepository.UpdateAsync(menu);
        return await Task.FromResult(menu.Id);
    }

    public async Task<Menu?> GetCompleteMenu(Guid menuId)
    {
        var menu = await _context.Menus
            .Include(m => m.Products)
            .Include(m => m.MenuLayouts)
            .Include(m => m.Categories)
            .FirstOrDefaultAsync(m => m.Id == menuId);

        if (menu == null)
            return default;

        return menu;
    }

    public async Task<Menu?> GetMenuBuildedLayout(Guid menuId)
    {
        var menu = await _context.Menus
            .Include(m => m.Products)
            .ThenInclude(p => p.Images)
            .FirstOrDefaultAsync(m => m.Id == menuId);

        if (menu == null)
            return default;

        var menuLayout = await _context.MenuLayouts
            .Where(ml => ml.MenuId == menuId)
            .OrderByDescending(ml => ml.CreatedAt)
            .LastAsync();

        menu.MenuLayouts = menuLayout == null ? [] : [menuLayout];

        return menu;
    }
}
