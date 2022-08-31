namespace Insurise.Application.Exceptions;

public class InsuriseHttpException : ApplicationException
{
    protected InsuriseHttpException(int statusCode, object? value = null)
    {
        (StatusCode, Value) = (statusCode, value);
    }

    public int StatusCode { get; }

    public object? Value { get; }
}