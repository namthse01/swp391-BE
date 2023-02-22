using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public abstract class AuditableBaseEntity
{
    [StringLength(256)] public string CreatedBy { get; set; }

    public DateTime Created { get; set; }

    [StringLength(256)] public string LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
}