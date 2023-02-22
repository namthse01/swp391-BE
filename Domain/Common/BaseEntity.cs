namespace Domain.Common;

public abstract class BaseEntity : AuditableBaseEntity, IEntity<Guid>, ISoftDelete
{
    public virtual Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}