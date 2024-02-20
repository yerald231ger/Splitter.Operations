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
                return _sptInterface.CompleteGet(command.CommandId, Product != null ? [Product] : new List<Product>());
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
}
