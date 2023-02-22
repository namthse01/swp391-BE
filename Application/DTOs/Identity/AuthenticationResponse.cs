using Domain.Common;
using Domain.Entities;

namespace Application.DTOs.Identity;

public class AuthenticationResponse
{
    public Guid Id { get; set; }
    public string Account { get; set; }

    public string Email { get; set; }

    //public Role Role { get; set; }
    public string JWToken { get; set; }
}