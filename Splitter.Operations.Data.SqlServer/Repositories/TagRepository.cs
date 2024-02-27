using Splitter.Extensions;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class TagRepository(SplitterDbContext dbContext)
: Repository<Tag, Guid>(dbContext), ITagRepository
{
}
