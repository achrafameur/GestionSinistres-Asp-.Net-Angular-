using JetBrains.Annotations;

namespace Insurise.Application.Exceptions;

public class TierNotFoundException : NotFoundException
{
    public TierNotFoundException(object value) : base($"Tier not found: {value}")
    {
    }
}

public class TierCompanyNotFoundException : NotFoundException
{
    public TierCompanyNotFoundException(object value) : base($"Tier Company not found: {value}")
    {
    }
}