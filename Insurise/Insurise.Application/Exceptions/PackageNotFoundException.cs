namespace Insurise.Application.Exceptions;

public class PackageNotFoundException : NotFoundException
{
    public PackageNotFoundException(object value) : base($"Package not found: {value}")
    {
    }
}