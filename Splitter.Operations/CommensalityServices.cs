using Microsoft.Extensions.Logging;
using Splitter.Operations.Constants;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;
using Splitter.Operations.Specification;
using Splitter.Extensions;
using Splitter.Extentions.Interface.Abstractions;

namespace Splitter.Operations;

public class CommensalityServices(
    ILogger<CommensalityServices> logger,
    ICommensalityUnitOfWork CommensalityUnitOfWork,
    ICommensalityRepository CommensalityRepository,
    ISptInterface sptInterface)
{
    private readonly ICommensalityUnitOfWork _commensalityUnitOfWork = CommensalityUnitOfWork;
    private readonly ICommensalityRepository _commensalityRepository = CommensalityRepository;
    private readonly ILogger<CommensalityServices> _logger = logger;
    private readonly ISptInterface _sptInterface = sptInterface;

    public async Task<SptResult> GetCommensalitysAsync(GetCommensalityCommand command)
    {
        try
        {
            _logger.LogInformation("Getting Commensality");
            if (command.CommensalityId != null && command.CommensalityId != Guid.Empty)
            {
                var commensality = await _commensalityRepository.GetByIdAsync(command.CommensalityId.Value);

                if (commensality != null)
                {
                    if (command.WithOrders)
                    {
                        var order = await _commensalityUnitOfWork.GetOrder(commensality.Id);
                        commensality.Order = order;
                    }

                    return _sptInterface.CompleteGet(command.CommandId, commensality!);
                }
                else
                    return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.NotFound, CommensalityRejectCodes.NotFound.GetDescription());
            }

            var specification = new GetByRangeDateEspecification<Commensality>(command.From, command.To, x => x.CreatedAt);
            var result = (IEnumerable<Commensality>)await _commensalityRepository.Filter(specification.IsSatisfiedBy);
            return _sptInterface.CompleteGet(command.CommandId, result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Commensality");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError, CommensalityRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> CreateCommensality(CreateCommensalityCommand command)
    {
        try
        {
            _logger.LogInformation("Creating Commensality");
            if (string.IsNullOrWhiteSpace(command.Name))
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidCommensalityName, CommensalityRejectCodes.InvalidCommensalityName.GetDescription());

            if (command.CommensalityId == Guid.Empty)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidCommensalityId, CommensalityRejectCodes.InvalidCommensalityId.GetDescription());

            var commensality = Commensality.Create(command.CommensalityId, command.Name);
            var result = await _commensalityUnitOfWork.CreateCommensalityAsync(commensality);
            return _sptInterface.CompleteCreate(command.CommandId, commensality);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating Commensality");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError);
        }
    }

    public async Task<SptResult> OrderProduct(CreateProductCommand command)
    {
        try
        {
            _logger.LogInformation("Ordering Product");

            var commensality = await _commensalityUnitOfWork.GetCommensality(command.CommensalityId);
            var order = commensality?.Order;

            if (commensality is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.CommensalityNotFound, CommensalityRejectCodes.CommensalityNotFound.GetDescription());

            if (string.IsNullOrWhiteSpace(command.ProductName))
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidProductName, CommensalityRejectCodes.InvalidProductName.GetDescription());

            if (commensality.HasOrder())
            {
                var product = Models.OrderProduct.Create(command.ProductId, command.ProductName, command.ProductPrice);
                order!.AddProduct(product);
            }
            else
            {
                order = Order.Create(command.CommensalityId);
                var product = Models.OrderProduct.Create(command.ProductId, command.ProductName, command.ProductPrice);
                order.AddProduct(product);
                commensality.AddOrder(order);
            }

            await _commensalityUnitOfWork.UpdateCommensality(commensality);
            await _commensalityUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteCreate(command.CommandId, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while ordering product");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError, CommensalityRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> DeleteProduct(DeleteCommensalityProductCommand command)
    {
        try
        {
            _logger.LogInformation("Removing Product");
            var commensality = await _commensalityUnitOfWork.GetCommensality(command.CommensalityId);
            var order = commensality?.Order;

            if (commensality is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.CommensalityNotFound, CommensalityRejectCodes.CommensalityNotFound.GetDescription());

            if (order is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderNotFound, CommensalityRejectCodes.OrderNotFound.GetDescription());

            if (order.Products!.Count == 0)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderWithoutProducts, CommensalityRejectCodes.OrderWithoutProducts.GetDescription());

            var product = order.Products.FirstOrDefault(x => x.Id == command.ProductId);

            if (product is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.NotFound, CommensalityRejectCodes.NotFound.GetDescription());

            order.RemoveProduct(product);
            await _commensalityUnitOfWork.UpdateOrder(order);
            await _commensalityUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteUpdate(command.CommandId, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while removing product");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError, CommensalityRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> CloseOrder(UpdateOrderCommand command)
    {
        try
        {
            _logger.LogInformation("Closing Order");
            var order = await _commensalityUnitOfWork.GetOrder(command.CommensalityId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderNotFound, CommensalityRejectCodes.OrderNotFound.GetDescription());

            order.Total = order.SumAllProducts();
            order.CloseOrder();

            await _commensalityUnitOfWork.UpdateOrder(order);

            return _sptInterface.CompleteUpdate(command.CommandId, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while closing order");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError, CommensalityRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> PayTotalOrder(CreateVoucherCommand command)
    {
        try
        {
            _logger.LogInformation("Paying Order");
            var order = await _commensalityUnitOfWork.GetOrder(command.CommensalityId);

            if (command.VoucherId == Guid.Empty)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidVaoucherId, CommensalityRejectCodes.InvalidVaoucherId.GetDescription());

            if (order is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderNotFound, CommensalityRejectCodes.OrderNotFound.GetDescription());

            if (order.IsPaid())
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderAlreadyPaid, CommensalityRejectCodes.OrderAlreadyPaid.GetDescription());

            if (order.Total > command.Amount)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InsufficientFunds, CommensalityRejectCodes.InsufficientFunds.GetDescription());

            if (command.Tip is < 0 or > 100)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidTip, CommensalityRejectCodes.InvalidTip.GetDescription());

            var voucher = Voucher.Create(command.VoucherId, command.Amount, command.Tip);
            order.AddVoucher(voucher);
            order.PaidOrder();

            await _commensalityUnitOfWork.UpdateOrder(order);
            await _commensalityUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteCreate(command.CommandId, voucher);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while paying order");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError, CommensalityRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> PayPartialOrder(CreateVoucherCommand command)
    {
        try
        {
            _logger.LogInformation("Paying Partial Order");
            var order = await _commensalityUnitOfWork.GetOrderWithVouchers(command.CommensalityId);
            
            if (command.VoucherId == Guid.Empty)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidVaoucherId, CommensalityRejectCodes.InvalidVaoucherId.GetDescription());

            if (order is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderNotFound, CommensalityRejectCodes.OrderNotFound.GetDescription());

            if (order.IsPaid())
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.OrderAlreadyPaid, CommensalityRejectCodes.OrderAlreadyPaid.GetDescription());

            if (command.Tip is < 0 or > 100)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidTip, CommensalityRejectCodes.InvalidTip.GetDescription());

            var voucher = Voucher.Create(command.VoucherId, command.Amount, command.Tip);
            order.AddVoucher(voucher);
            await _commensalityUnitOfWork.UpdateOrder(order);
            await _commensalityUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteCreate(command.CommandId, voucher);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while paying partial order");
            return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.RepositoryError, CommensalityRejectCodes.RepositoryError.GetDescription());
        }
    }
}