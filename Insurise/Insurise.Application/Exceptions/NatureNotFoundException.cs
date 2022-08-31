namespace Insurise.Application.Exceptions;

public class NatureNotFoundException : NotFoundException
{
    public NatureNotFoundException(object value) : base($"Nature not found {value}")
    {
    }
}