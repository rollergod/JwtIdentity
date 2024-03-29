using System.Net;
using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Application.Constants;
using JwtIdentity.Domain.Common.Contracts.DTO;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using JwtIdentity.Api.Filters;

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
    [ServiceFilter(typeof(ModelStateFilter))]
    [ProducesResponseType(typeof(RegisterResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(RegisterResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        var user = _mapper.Map<User>(model);

        var result = await _userService.Register(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result);

        var encodedToken = Uri.EscapeDataString(result.Data.Code);
        string callbackUrl = $"{ServerUrls.API_URL}/{ServerUrls.API_URL_CONFIRM_EMAIL}?userId={user.Id}&code={encodedToken}";

        string messageBody = "Please verify email by going to this <a href=\"" + callbackUrl + "\">link</a>";

        var isEmailSended = await _accountService.SendEmail(messageBody, user.Email);

        var registerResponse = _mapper.Map<RegisterResponse>(isEmailSended);

        if (!isEmailSended.Succeeded)
            return BadRequest(registerResponse);

        return Ok(registerResponse);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ModelStateFilter))]
    [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var result = await _userService.Login(model.Email, model.Password);

        if (!result.Succeeded)
            return BadRequest(result);

        return Ok(result.Data);
    }

    // TODO : доедлать эту фигню для пользователя на фронте 
    [HttpPost("forgotpassword")]
    [ServiceFilter(typeof(ModelStateFilter))]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        var tokenObject = await _accountService.GenerateResetToken(model.Email);

        if (!tokenObject.Succeeded)
            return BadRequest(tokenObject);

        var encodedToken = Uri.EscapeDataString(tokenObject.Data.Code);

        string callbackUrl = $"{ServerUrls.API_URL}/{ServerUrls.API_URL_RESET_PASSWORD}?code={encodedToken}";

        string messageBody = "Please reset password by going to this <a href=\"" + callbackUrl + "\">link</a>";

        var isEmailSended = await _accountService.SendEmail(messageBody, model.Email);

        if (!isEmailSended.Succeeded)
            return BadRequest(isEmailSended);

        return Ok(isEmailSended);
    }

    [HttpGet("resetpassword")]
    public IActionResult ResetPassword(string code)
    {
        return Ok(code);
    }

    [HttpPost("resetpassword")]
    [ServiceFilter(typeof(ModelStateFilter))]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordViewModel)
    {
        var result = await _accountService.ResetPassword(
            resetPasswordViewModel.Email,
            resetPasswordViewModel.Password,
            resetPasswordViewModel.Code
        );

        if (result.Succeeded)
            return Ok(result); //TODO : добавить response object

        return BadRequest(result);
    }

    [HttpGet("confirmemail")]
    [ProducesResponseType(typeof(EmailConfirmationResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(EmailConfirmationResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            return BadRequest("Invalid email confirmation url");

        var isUserExist = await _accountService.EmailConfirmationAsync(userId, code);

        if (!isUserExist.Succeeded)
            return BadRequest(isUserExist);

        return Ok(isUserExist);
    }

}