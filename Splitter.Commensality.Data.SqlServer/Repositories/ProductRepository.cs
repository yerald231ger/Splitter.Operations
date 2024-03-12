using Splitter.Extensions;
using Splitter.Commensality.Infrastructure;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class ProductRepository(SplitterDbContext dbContext)
: Repository<OrderProduct, Guid>(dbContext), IProductRepository
{
    
}
