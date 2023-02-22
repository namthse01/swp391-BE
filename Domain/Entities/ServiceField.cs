using Domain.Common;

namespace Domain.Entities;

public class ServiceField : BaseEntity
{
    public Guid ServiceId { get; set; }
    public Guid FieldId { get; set; }

    public Service Service { get; set; }
    public Field Field { get; set; }
}