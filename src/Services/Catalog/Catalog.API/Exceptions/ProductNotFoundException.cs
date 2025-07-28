﻿using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException()
        : base("Product not found.")
    {
    }

    public ProductNotFoundException(Guid productId)
        : base($"Product with ID '{productId}' not found.")
    {
    }
}
