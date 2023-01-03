using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JwtIdentity.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public AuthService(
        UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IMapper mapper)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mapper = mapper;
    }

    public async Task<Response<LoginResponse>> Login(string email, string password)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);

        if (existingUser == null)
            return Response<LoginResponse>.Fail("User doesn`t exist. Register and then log in");

        if (!existingUser.EmailConfirmed)
            return Response<LoginResponse>.Fail("User doesn`t confirm his email. Check your email and confirm account");

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(existingUser, password);

        if (!isPasswordCorrect)
            return Response<LoginResponse>.Fail("Users password isn`t correct");

        var token = _jwtTokenGenerator.GenerateToken(existingUser);

        var tokenResponse = _mapper.Map<LoginResponse>((existingUser, token));

        return Response<LoginResponse>.Success(
            data: tokenResponse,
            message: "Successful authorization"
        );
    }

    public async Task<Response<RegisterResponse>> Register(User model, string password)
    {
        var isUserExistWithEmail = await _userManager.FindByEmailAsync(model.Email);

        if (isUserExistWithEmail != null)
            return Response<RegisterResponse>.Fail("This email is already being used by someone ");

        var isUserExistWithNickName = await _userManager.Users.FirstOrDefaultAsync(u => u.DisplayName == model.DisplayName);

        if (isUserExistWithNickName != null)
            return Response<RegisterResponse>.Fail("This nickname is already being used by someone ");

        var isCreated = await _userManager.CreateAsync(model, password);

        if (isCreated.Succeeded)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(model);

            var registerResponse = new RegisterResponse { Code = code };

            return Response<RegisterResponse>.Success(
                data: registerResponse,
                message: "User registered successfully. Confirm email");
        }

        var errorList = isCreated.Errors.ToList();

        return Response<RegisterResponse>.Fail(errors: errorList.Select(e => e.Description).ToList());
    }
}