using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class ProductRepository(SplitterDbContext dbContext)
: Repository<OrderProduct, Guid>(dbContext), IProductRepository
{
    
}
