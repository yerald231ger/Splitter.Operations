using System.Dynamic;
using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface ICommensalityRepository : IRepository<Commensality, Guid>
{
    Task<Commensality?> GetCommensalityWithOrder(Guid commensalityId);
}
