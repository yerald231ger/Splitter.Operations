using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderTableRepository(SplitterDbContext dbContext)
: Repository<Order, Guid>(dbContext), IOrderTableRepository
{
    
}
