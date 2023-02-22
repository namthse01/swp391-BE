using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Identity;

public class SetPasswordRequest
{
    [Required] [MinLength(6)] public string Password { get; set; }

    [Required] [Compare("Password")] public string ConfirmPassword { get; set; }
}