namespace Insurise.Application.Exceptions;

public class DocumentNotFoundException : NotFoundException
{
    public DocumentNotFoundException(object value) : base($"Document not found: {value}")
    {
    }
}