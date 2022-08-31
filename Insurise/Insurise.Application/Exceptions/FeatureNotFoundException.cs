namespace Insurise.Application.Exceptions;

public class FeatureNotFoundException : NotFoundException
{
    public FeatureNotFoundException(object value) : base($"Feature not found: {value}")
    {
    }
}