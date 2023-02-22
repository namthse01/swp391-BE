using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    [StringLength(255)] public string Username { get; set; }

    [StringLength(255)] public string Password { get; set; }

    [StringLength(255)] public string Email { get; set; }

    [StringLength(20)] public string Phone { get; set; }

    public Collection<Player> Players { get; set; }
    public Collection<Manager> Managers { get; set; }
}