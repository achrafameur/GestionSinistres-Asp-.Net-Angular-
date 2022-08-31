using JetBrains.Annotations;

namespace Insurise.Application.Exceptions;

public class CommissionNotFoundException : NotFoundException
{
    public CommissionNotFoundException(object value) : base($"Commission not found: {value}")
    {
    }
}