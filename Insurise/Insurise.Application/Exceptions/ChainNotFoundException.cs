namespace Insurise.Application.Exceptions;

public class ChainNotFoundException : NotFoundException
{
    public ChainNotFoundException(object key) : base($"Chain not found: {key}")
    {
    }
}