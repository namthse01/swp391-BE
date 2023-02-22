using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Transaction : BaseEntity
{
    [StringLength(255)] public string Name { get; set; }
    public int Slot { get; set; }
    public DateTime Date { get; set; }

    public Guid PlayerId { get; set; }
    public Guid FieldId { get; set; }

    public Player Player { get; set; }
    public Field Field { get; set; }

    public Order Order { get; set; }

    public Collection<TransactionService> TransactionServices { get; set; }
}