namespace Insurise.SharedKernel;

public abstract class BaseEntity<T> : AuditedEntityBase
{
    protected BaseEntity()
    {
    }

    public T? Id { get; set; }
    public readonly List<BaseDomainEvent> Events = new();
}