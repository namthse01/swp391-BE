using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Order : BaseEntity
{
    [StringLength(255)] public string Name { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid TransactionId { get; set; }

    public Transaction Transaction { get; set; }
}