namespace Insurise.Application.Exceptions;

public class DurationNotFoundException : NotFoundException
{
    public DurationNotFoundException(object value) : base($"Duration not found: {value}")
    {
    }
}