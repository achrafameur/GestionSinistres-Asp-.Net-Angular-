using Insurise.Crosscutting.Constants;

namespace Insurise.Crosscutting.Exceptions;

public class BadRequestAlertException : BaseException
{
    public BadRequestAlertException(string detail, string entityName, string errorKey) : this(
        ErrorConstants.DefaultType, detail, entityName, errorKey)
    {
    }

    protected BadRequestAlertException(string type, string detail, string entityName, string errorKey) : base(type,
        detail, entityName, errorKey)
    {
    }
}