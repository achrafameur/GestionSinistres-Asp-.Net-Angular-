namespace Insurise.Application.Exceptions;

public class StatusNotFoundException : NotFoundException
{
    public StatusNotFoundException(object value) : base($"Status not found: {value}")
    {
    }
}