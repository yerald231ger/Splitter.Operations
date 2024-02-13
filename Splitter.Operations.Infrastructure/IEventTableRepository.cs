using System.Dynamic;
using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IEventTableRepository : IRepository<EventTable, Guid>
{
    Task<EventTable?> GetEventTableWithOrder(Guid eventTableId);
}
