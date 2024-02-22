using Splitter.Operations.Constants;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;
using Splitter.Operations.Specification;

namespace Splitter.Operations;

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
                return _sptInterface.CompleteGet(command.CommandId, (IEnumerable<Product>)(Product is null ? [] : [Product]));
            }
            var specification = new GetByNameSpecification<Product>(command.Name, x => x.Name);
            var result = (IEnumerable<Product>)await _productRepository.Filter(specification.IsSatisfiedBy);
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
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InvalidResourceIdentifier, SptRejectCodes.NotFound.GetDescription());

            var Product = await _productRepository.GetByIdAsync(command.ProductId.Value);
            if (Product is null)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.NotFound, SptRejectCodes.NotFound.GetDescription());

            await _productRepository.DeleteAsync(Product);
            return _sptInterface.CompleteUpdate(command.CommandId, Product);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
