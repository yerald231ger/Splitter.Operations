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
        try
        {
            if (command.OrderId != null && command.OrderId != Guid.Empty)
            {
                var order = await _orderRepository.GetByIdAsync(command.OrderId.Value);
                return _sptInterface.CompleteGet(command.CommandId, order != null ? [order] : new List<Order>());
            }
    
            var result = (IEnumerable<Order>)await _orderRepository.Filter(command.From, command.To, command.WithProducts, command.WithVouchers);
            return _sptInterface.CompleteGet(command.CommandId, result);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}
