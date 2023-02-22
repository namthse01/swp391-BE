using Domain.Common;

namespace Domain.Entities;

public class TransactionService : BaseEntity
{
    public Guid ServiceId { get; set; }
    public Guid TransactionId { get; set; }

    public Service Service { get; set; }
    public Transaction Transaction { get; set; }
}