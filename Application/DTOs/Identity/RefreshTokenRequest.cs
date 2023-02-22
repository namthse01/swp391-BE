namespace Application.DTOs.Identity;

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; }
}

public class RevokeTokenRequest : RefreshTokenRequest
{
}