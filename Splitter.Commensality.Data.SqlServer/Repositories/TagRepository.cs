using Splitter.Extensions;
using Splitter.Commensality.Infrastructure;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class TagRepository(SplitterDbContext dbContext)
: Repository<Tag, Guid>(dbContext), ITagRepository
{
}
