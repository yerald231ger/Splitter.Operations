using Splitter.BCMenu.Data.SqlServer;
using Splitter.Extensions;
using Splitter.BCMenu.Infrastructure;
using Splitter.BCMenu.Models;

namespace Splitter.Operations.Data.SqlServer;

public class MenuRepository(MenuDbContext dbContext)
: Repository<Menu, Guid>(dbContext), IMenuRepository
{
    
}