using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class TagRepository(DbContext dbContext)
: Repository<Tag, Guid>(dbContext), ITagRepository
{
}
