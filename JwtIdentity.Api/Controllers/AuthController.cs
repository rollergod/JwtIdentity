using System.Net;
using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common;
using JwtIdentity.Domain.Common.Contracts.DTO;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtIdentity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                UserName = model.Name,
                DisplayName = model.NickName,
                Email = model.Email
            };

            var result = await _userService.Register(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.ToString());

            return Ok(result.Message);
        }
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.Login(model.Email, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.ToString());

            return Ok(result.Data);
        }
        return BadRequest(ModelState);
    }
}