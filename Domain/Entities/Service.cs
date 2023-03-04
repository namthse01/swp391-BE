using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Service : BaseEntity
{
    [StringLength(255)] public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid? ManagerId { get; set; }

    public Manager Manager { get; set; }
    public Collection<ServiceField> ServiceFields { get; set; }
    public Collection<TransactionService> TransactionServices { get; set; }
}