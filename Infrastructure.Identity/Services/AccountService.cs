using Application.DTOs.Identity;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IMP.Application.Interfaces;

namespace Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<User> _userRepository;
        private readonly JWTSettings _jwtSettings;
        private readonly IGoogleService _googleService;

        public AccountService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            IOptions<JWTSettings> options, IGoogleService googleService)
        {
            _httpContextAccessor = httpContextAccessor;
            _googleService = googleService;
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.Repository<User>();
            _jwtSettings = options.Value;
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userRepository.GetAll(user => EF.Functions.Like(user.Email, request.Email))
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ValidationException($"No Accounts Registered with {request.Email}.");
            }

            var isCorrectPassword = EncodePasswordToBase64(request.Password) == user.Password;
            if (!isCorrectPassword)
            {
                throw new ValidationException($"Invalid Credentials for '{request.Email}'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.Account = user.Username;

            return new Response<AuthenticationResponse>(response, $"Authenticated {user.Email}");
        }

        public async Task<Response<AuthenticationResponse>> GoogleAuthenticateAsync(
            GoogleAuthenticationRequest request)
        {
            var userInfo = await _googleService.ValidateIdToken(request.Token);
            if (userInfo == null)
            {
                throw new ValidationException("Token not valid");
            }

            var user = await _userRepository.GetAll(user => EF.Functions.Like(user.Email, userInfo.Email))
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ValidationException($"No Accounts Registered with {userInfo.Email}.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.Account = user.Username;

            return new Response<AuthenticationResponse>(response, $"Authenticated {user.Email}");
        }

        private async Task<JwtSecurityToken> GenerateJWToken(User User)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, User.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, User.Email),
                new Claim("uid", User.Id.ToString()),
                //new Claim(ClaimTypes.Role, User.Role.ToString()),
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }


        private RefreshTokenResponse GenerateRefreshToken(string ipAddress)
        {
            return new RefreshTokenResponse
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
    }
}