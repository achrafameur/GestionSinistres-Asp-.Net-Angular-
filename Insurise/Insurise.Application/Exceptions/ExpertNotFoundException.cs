namespace Insurise.Application.Exceptions;

public class ExpertNotFoundException : NotFoundException
{
    public ExpertNotFoundException(object value) : base($"Expert not found: {value}")
    {
    }
}