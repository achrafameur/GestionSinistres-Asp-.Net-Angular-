namespace Insurise.Application.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(object value) : base($"Product not found: {value}")
    {
    }
}

public class ProductFeeNotFoundException : NotFoundException
{
    public ProductFeeNotFoundException(object value) : base($"Product Fee not found: {value}")
    {
    }
}

public class ProductShopNotFoundException : NotFoundException
{
    public ProductShopNotFoundException(object value) : base($"Product Shop not found: {value}")
    {
    }
}

public class ProductWarrantyNotFoundException : NotFoundException
{
    public ProductWarrantyNotFoundException(object value) : base($"Product Warranty not found: {value}")
    {
    }
}

public class ProductDurationNotFoundException : NotFoundException
{
    public ProductDurationNotFoundException(object value) : base($"Product Duration not found: {value}")
    {
    }
}