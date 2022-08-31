using Insurise.SharedKernel.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Insurise.SharedKernel;

public abstract class AuditedEntityBase : IAuditedEntityBase
{

    [field: NonSerialized]
    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; } = string.Empty;

    [field: NonSerialized] [Required] public DateTime CreatedDate { get; set; }

    [field: NonSerialized] public string? LastModifiedBy { get; set; }

    [field: NonSerialized] public DateTime? LastModifiedDate { get; set; }

    [field: NonSerialized]
    [StringLength(50)]
    public string? IpAddress { get; set; }

    [field: NonSerialized] [Required] public bool IsDeleted { get; set; }
}