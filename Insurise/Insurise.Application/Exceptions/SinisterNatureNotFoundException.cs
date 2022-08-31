namespace Insurise.Application.Exceptions;

public class SinisterNatureNotFoundException : NotFoundException
{
    public SinisterNatureNotFoundException(object value) : base($"Sinister nature not found: {value}")
    {
    }
}