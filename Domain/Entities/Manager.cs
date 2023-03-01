using Domain.Common;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Manager : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }

    public Collection<Service> Services { get; set; }
    public Collection<Field> Fields { get; set; }
    public Collection<User> Users { get; set; }
    public Collection<Role> Roles { get; set; }
}