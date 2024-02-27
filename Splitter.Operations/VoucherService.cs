using Splitter.Extentions.Interface.Abstractions;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;
using Splitter.Operations.Specification;

namespace Splitter.Operations;

public class VoucherService(IVoucherRepository voucherRepository, ISptInterface sptInterface)
{
    private readonly IVoucherRepository _voucherRepository = voucherRepository;
    private readonly ISptInterface _sptInterface = sptInterface;

    public async Task<SptResult> GetvouchersAsync(GetVoucherCommand command)
    {
        try
        {

            if (command.VoucherId != null && command.VoucherId != Guid.Empty)
            {
                var voucher = await _voucherRepository.GetByIdAsync(command.VoucherId.Value);
                return _sptInterface.CompleteGet(command.CommandId, (IEnumerable<Voucher>)(voucher is null ? [] : [voucher]));
            }

            var specification = new GetByRangeDateEspecification<Voucher>(command.From, command.To, x => x.CreatedAt);
            var result = (IEnumerable<Voucher>)await _voucherRepository.Filter(specification.IsSatisfiedBy);
            return _sptInterface.CompleteGet(command.CommandId, result);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
