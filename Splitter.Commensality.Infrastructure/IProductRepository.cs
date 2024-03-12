using Splitter.Extensions;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Infrastructure;

public interface IProductRepository : IRepository<OrderProduct, Guid>
{
    
}
