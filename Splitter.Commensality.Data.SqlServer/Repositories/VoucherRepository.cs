using Splitter.Extensions;
using Splitter.Commensality.Infrastructure;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class VoucherRepository(SplitterDbContext dbContext)
: Repository<Voucher, Guid>(dbContext), IVoucherRepository
{
}
