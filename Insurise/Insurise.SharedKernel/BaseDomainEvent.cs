using MediatR;

namespace Insurise.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
    public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
}