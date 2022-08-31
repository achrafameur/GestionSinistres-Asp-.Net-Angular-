namespace Insurise.Application.Exceptions;

public class ItemNotFoundException : NotFoundException
{
    public ItemNotFoundException(object value) : base($"Item not found: {value}")
    {
    }
}