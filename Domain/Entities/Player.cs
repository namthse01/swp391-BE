using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Player : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Collection<Transaction> Transactions { get; set; }
}