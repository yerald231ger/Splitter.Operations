using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderRepository(SplitterDbContext dbContext)
: Repository<Order, Guid>(dbContext), IOrderRepository
{
}
