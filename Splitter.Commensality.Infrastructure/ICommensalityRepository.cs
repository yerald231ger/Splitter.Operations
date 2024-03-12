using Splitter.Extensions;

namespace Splitter.Commensality.Infrastructure;

public interface ICommensalityRepository : IRepository<Models.Commensality, Guid>
{
    Task<Models.Commensality?> GetCommensalityWithOrder(Guid commensalityId);
}
