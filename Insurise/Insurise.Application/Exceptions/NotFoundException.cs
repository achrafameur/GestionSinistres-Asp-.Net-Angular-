namespace Insurise.Application.Exceptions;

public class NotFoundException : InsuriseHttpException
{
    protected NotFoundException(object value) : base(404, value)
    {
    }
}