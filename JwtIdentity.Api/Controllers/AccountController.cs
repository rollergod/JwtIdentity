using System.Net;
using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common;
using JwtIdentity.Domain.Common.Contracts.DTO;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using MapsterMapper;
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
    private readonly IMapper _mapper;
    public AccountController(IAuthService userService,
                            IAccountService accountService,
                            IMapper mapper)
    {
        _userService = userService;
        _accountService = accountService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(RegisterResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userService.Register(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result);

            var encodedToken = Uri.EscapeDataString(result.Data.Code);
            string callbackUrl = $"http://localhost:3000/confirmemail?userId={user.Id}&code={encodedToken}";

            string messageBody = "Please verify email by going to this <a href=\"" + callbackUrl + "\">link</a>";

            var isEmailSended = await _accountService.SendEmail(messageBody, user.Email);

            var registerResponse = _mapper.Map<RegisterResponse>(isEmailSended);

            if (!isEmailSended.Succeeded)
                return BadRequest(registerResponse);

            return Ok(registerResponse);
        }
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.Login(model.Email, model.Password);

            if (!result.Succeeded)
                return BadRequest(result);

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
                return BadRequest("The token cant be created");

            var callbackUrl = Url.Action(
                "ResetPassword",
                "Account",
                new { code = tokenObject.Data.Code, userId = tokenObject.Data.User.Id },
                protocol: HttpContext.Request.Scheme
            );

            string messageBody = "Please reset password by going to this <a href=\"" + callbackUrl + "\">link</a>";

            var isEmailSended = await _accountService.SendEmail(messageBody, email);

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

    [HttpGet("confirmemail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            return BadRequest("Invalid email confirmation url");

        var isUserExist = await _accountService.EmailConfirmationAsync(userId, code);

        if (!isUserExist.Succeeded)
            return BadRequest(isUserExist.Message);

        return Ok(isUserExist.Message);
    }

}