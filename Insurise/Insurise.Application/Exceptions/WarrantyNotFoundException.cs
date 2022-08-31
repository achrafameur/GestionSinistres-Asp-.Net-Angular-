namespace Insurise.Application.Exceptions;

public class WarrantyNotFoundException : NotFoundException
{
    public WarrantyNotFoundException(object value) : base($"Warranty not found: {value}")
    {
    }
}

public class WarrantyTaxNotFoundException : NotFoundException
{
    public WarrantyTaxNotFoundException(object value) : base($"Warranty Tax not found: {value}")
    {
    }
}

public class WarrantyFeatureNotFoundException : NotFoundException
{
    public WarrantyFeatureNotFoundException(object value) : base($"Warranty Feature not found: {value}")
    {
    }
}

public class WarrantyCommissionNotFoundException : NotFoundException
{
    public WarrantyCommissionNotFoundException(object value) : base($"Warranty Commission not found: {value}")
    {
    }
}