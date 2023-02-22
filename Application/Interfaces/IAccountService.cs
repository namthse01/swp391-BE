using Application.DTOs.Identity;
using Application.Wrappers;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
}