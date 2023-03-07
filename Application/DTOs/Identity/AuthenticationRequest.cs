namespace Application.DTOs.Identity;

public class AuthenticationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class GoogleAuthenticationRequest
{
    public string Token { get; set; }
}