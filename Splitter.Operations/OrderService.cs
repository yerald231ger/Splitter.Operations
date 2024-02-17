using Splitter.Operations.Constants;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations;

public class OrderService(IOrderRepository orderRepository, ISptInterface sptInterface)
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly ISptInterface _sptInterface = sptInterface;

    public async Task<SptResult> GetOrdersAsync(GetOrderCommand command)
    {
        var orders = await _orderRepository.GetAsync();
        if (command.OrderId != Guid.Empty)
            return _sptInterface.CompleteGet(command.CommandId, orders.Where(x => x.Id == command.OrderId).ToList());

        if (command.From != null && command.To == null)
            return _sptInterface.CompleteGet(command.CommandId, orders.Where(x => x.CreatedAt >= command.From).ToList());

        if (command.From == null && command.To != null)
            return _sptInterface.CompleteGet(command.CommandId, orders.Where(x => x.CreatedAt <= command.To).ToList());

        if (command.From != null && command.To != null)
            if (command.From > command.To)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InvalidSearchRange, SptRejectCodes.InvalidSearchRange.GetDescription());

        var result = await _orderRepository.GetAsync();

        return _sptInterface.CompleteGet(command.CommandId, result);
    }
}
