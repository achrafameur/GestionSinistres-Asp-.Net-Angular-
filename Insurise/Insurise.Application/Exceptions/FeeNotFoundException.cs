namespace Insurise.Application.Exceptions;

public class FeeNotFoundException : NotFoundException
{
    public FeeNotFoundException(object value) : base($"Fee not found: {value}")
    {
    }
}