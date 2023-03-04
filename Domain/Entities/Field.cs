using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Field : BaseEntity
{
    [StringLength(255)] public string Name { get; set; }
    [StringLength(2000)] public string Description { get; set; }
    [StringLength(255)] public string Address { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? ManagerId { get; set; }
    public Enums.FieldStatus Type { get; set; }
    public Category Category { get; set; }
    public Manager Manager { get; set; }

    public Collection<ServiceField> ServiceFields { get; set; }
    public Collection<Transaction> Transactions { get; set; }
    //ko ro
    public Collection<User> Users { get; set; }
}