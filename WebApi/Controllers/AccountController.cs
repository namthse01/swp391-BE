using Application.DTOs.Identity;
using Application.Interfaces;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Constants;

namespace WebApi.Controllers
{
    [Route(RouterConstants.Account)]

    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Authenticate with email and password
        /// </summary>
        /// <param name="request">The Authentication Request</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<AuthenticationResponse>), (int)HttpStatusCode.OK)]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var response = await _accountService.AuthenticateAsync(request);
            return Ok(response);
        }
    }
}
