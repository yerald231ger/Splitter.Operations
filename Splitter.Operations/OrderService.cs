using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;
using Splitter.Operations.Specification;

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

                if (order != null)
                { 
                    if (command.WithVouchers)
                    {
                        var vouchers = await _orderRepository.GetVouchers(order.Id);
                        order.Vouchers = vouchers;
                    }

                    if (command.WithProducts)
                    {
                        var products = await _orderRepository.GetProducts(order.Id);
                        order.Products = products;
                    }
                }

                return _sptInterface.CompleteGet(command.CommandId, (IEnumerable<Order>)(order is null ? [] : [order]));
            }

            var specification = new GetByRangeDateEspecification<Order>(command.From, command.To, x => x.CreatedAt);
            var result = (IEnumerable<Order>)await _orderRepository.Filter(specification.IsSatisfiedBy);
            return _sptInterface.CompleteGet(command.CommandId, result);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}

