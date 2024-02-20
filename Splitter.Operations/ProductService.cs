using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

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
   
           var result = (IEnumerable<Product>)await _productRepository.Filter(null);
           return _sptInterface.CompleteGet(command.CommandId, result);
     }
     catch (System.Exception)
     {
        
        throw;
     }
    }
}
