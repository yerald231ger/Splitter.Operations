using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class VoucherRepository(DbContext dbContext)
: Repository<Voucher, Guid>(dbContext), IVoucherRepository
{
}
