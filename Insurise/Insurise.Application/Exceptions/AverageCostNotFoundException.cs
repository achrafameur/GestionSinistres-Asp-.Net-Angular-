namespace Insurise.Application.Exceptions;

public class AverageCostNotFoundException : NotFoundException
{
    public AverageCostNotFoundException(object value) : base($"Average cost not found: {value}")
    {
    }
}