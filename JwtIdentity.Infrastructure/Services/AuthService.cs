using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace JwtIdentity.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;

    public AuthService(
        UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public async Task<Response<TokenResponse>> Login(string email, string password)
    {
        var isUserExist = await _userManager.FindByEmailAsync(email);

        if (isUserExist == null)
            return Response<TokenResponse>.Fail("User doesn`t exist");

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(isUserExist, password);

        if (!isPasswordCorrect)
            return Response<TokenResponse>.Fail("User`s password isnt correct");

        var token = _jwtTokenGenerator.GenerateToken(isUserExist);

        var tokenResponse = (isUserExist, token).Adapt<TokenResponse>(); //mapster

        return Response<TokenResponse>.Success(
            data: tokenResponse,
            message: "Successful authorization"
        );
    }

    public async Task<Response<string>> Register(User model, string password)
    {
        var isUserExist = await _userManager.FindByEmailAsync(model.Email);

        if (isUserExist != null)
            return Response<string>.Fail("User is existing");

        var isCreated = await _userManager.CreateAsync(model, password);

        if (isCreated.Succeeded)
            return Response<string>.Success("User registered successfully");

        var errorList = isCreated.Errors.ToList();

        return Response<string>.Fail(errors: errorList.Select(e => e.Description).ToList());
    }
}