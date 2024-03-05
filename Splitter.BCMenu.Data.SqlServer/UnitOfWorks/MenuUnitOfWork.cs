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
            .FirstOrDefaultAsync(m => m.Id == menuId);

        if(menu == null)
            return default;

        return menu;
    }
}
