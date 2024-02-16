﻿using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record ProductDto(Guid id, string name, decimal price)
{
    public static ProductDto ToDto(Product product) =>
        new(product.Id, product.Name, product.Price);
}
#pragma warning restore IDE1006 // Naming Styles