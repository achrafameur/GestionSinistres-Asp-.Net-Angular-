namespace Insurise.SharedKernel.Interfaces;

public interface IAuditedEntityBase
{
    string CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    string? LastModifiedBy { get; set; }
    DateTime? LastModifiedDate { get; set; }
    string? IpAddress { get; set; }
    bool IsDeleted { get; set; }
}