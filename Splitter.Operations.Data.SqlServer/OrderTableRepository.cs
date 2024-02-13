using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderTableRepository(SplitterDbContext dbContext)
: Repository<OrderTable, Guid>(dbContext), IOrderTableRepository
{
    
}
