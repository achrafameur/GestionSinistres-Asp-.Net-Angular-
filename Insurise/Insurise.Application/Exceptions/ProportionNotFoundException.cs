namespace Insurise.Application.Exceptions;

public class ProportionNotFoundException : NotFoundException
{
    public ProportionNotFoundException(object value) : base($"Proportion not found: {value}")
    {
    }
}