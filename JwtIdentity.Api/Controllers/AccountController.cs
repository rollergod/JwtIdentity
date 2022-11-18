using System.Net;
using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common;
using JwtIdentity.Domain.Common.Contracts.DTO;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace JwtIdentity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthService _userService;
    private readonly IAccountService _accountService;
    private readonly IEmailService _emailService;
    public AccountController(IAuthService userService,
                            IAccountService accountService)
    {
        _userService = userService;
        _accountService = accountService;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = model.Adapt<User>();

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

    [HttpPost("forgotpassword")]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        if (ModelState.IsValid)
        {
            var tokenObject = await _accountService.GenerateResetToken(email);

            if (!tokenObject.Succeeded)
                return BadRequest("The token can`t be created");

            var callbackUrl = Url.Action(
                "ResetPassword",
                "Account",
                new { code = tokenObject.Data.Code, userId = tokenObject.Data.User.Id },
                protocol: HttpContext.Request.Scheme
            );

            var isEmailSended = await _accountService.SendEmail(callbackUrl, email);

            if (!isEmailSended.Succeeded)
                return BadRequest("Something went wrong while sending email");

            return Ok("Email sended successfully");
        }
        return BadRequest(ModelState);
    }

    [HttpGet("resetpassword")]
    public IActionResult ResetPassword(string code)
    {
        return Ok(code);
    }


    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.ResetPassword(
                resetPasswordViewModel.Email,
                resetPasswordViewModel.Password,
                resetPasswordViewModel.Code
            );

            if (result.Succeeded)
                return Ok();
        }

        return BadRequest(ModelState);
    }
}