namespace Insurise.Application.Exceptions;

public class ShopNotFoundException : NotFoundException
{
    public ShopNotFoundException(object value) : base($"Shop not found: {value}")
    {
    }
}