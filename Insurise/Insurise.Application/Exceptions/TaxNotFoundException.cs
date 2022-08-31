namespace Insurise.Application.Exceptions;

public class TaxNotFoundException : NotFoundException
{
    public TaxNotFoundException(object value) : base($"Tax not found: {value}")
    {
    }
}