namespace Insurise.Application.Exceptions;

public class BranchNotFoundException : NotFoundException
{
    public BranchNotFoundException(object key) : base($"Branch not found: {key}")
    {
    }
}