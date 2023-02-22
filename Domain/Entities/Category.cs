using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Category : BaseEntity
{
    [StringLength(255)] public string Name { get; set; }
}