using Splitter.Commensality.Constants;
using Splitter.Commensality.Infrastructure;
using Splitter.Commensality.Interface;
using Splitter.Commensality.Models;
using Splitter.Commensality.Specification;
using Splitter.Extensions;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Commensality;

public class ProductService(IProductRepository ProductRepository, ISptInterface sptInterface)
{
    private readonly IProductRepository _productRepository = ProductRepository;
    private readonly ISptInterface _sptInterface = sptInterface;

    public async Task<SptResult> GetProductsAsync(GetProductCommand command)
    {
        try
        {
            if (command.ProductId != null && command.ProductId != Guid.Empty)
            {
                var Product = await _productRepository.GetByIdAsync(command.ProductId.Value);
                return _sptInterface.CompleteGet(command.CommandId, (IEnumerable<OrderProduct>)(Product is null ? [] : [Product]));
            }
            var specification = new GetByNameSpecification<OrderProduct>(command.Name, x => x.Name);
            var result = (IEnumerable<OrderProduct>)await _productRepository.Filter(specification.IsSatisfiedBy);
            return _sptInterface.CompleteGet(command.CommandId, result);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task<SptResult> DeleteProductAsync(DeleteProductCommand command)
    {
        try
        {
            if (command.ProductId == null || command.ProductId == Guid.Empty)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.InvalidResourceIdentifier, CommensalityRejectCodes.NotFound.GetDescription());

            var Product = await _productRepository.GetByIdAsync(command.ProductId.Value);
            if (Product is null)
                return _sptInterface.Reject(command.CommandId, CommensalityRejectCodes.NotFound, CommensalityRejectCodes.NotFound.GetDescription());

            await _productRepository.DeleteAsync(Product);
            return _sptInterface.CompleteUpdate(command.CommandId, Product);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
