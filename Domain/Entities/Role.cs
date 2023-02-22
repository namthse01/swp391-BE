using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Role : BaseEntity
{
    [StringLength(255)] public string Name { get; set; }
    public Collection<Manager> Managers { get; set; }
}