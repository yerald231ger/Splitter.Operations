using Splitter.Extensions;
using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IProductRepository : IRepository<OrderProduct, Guid>
{
    
}
