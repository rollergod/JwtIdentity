using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

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
    public async Task<Response<TokenResponse>> Login(string email, string password)
    {
        var isUserExist = await _userManager.FindByEmailAsync(email);

        if (isUserExist == null)
            return Response<TokenResponse>.Fail("User doesnt exist");

        if (!isUserExist.EmailConfirmed)
            return Response<TokenResponse>.Fail("User doesnt confirm his email");

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(isUserExist, password);

        if (!isPasswordCorrect)
            return Response<TokenResponse>.Fail("Users password isnt correct");

        var token = _jwtTokenGenerator.GenerateToken(isUserExist);

        var tokenResponse = _mapper.Map<TokenResponse>((isUserExist, token));

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
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(model);

            return Response<string>.Success(
                data: code,
                message: "User registered successfully. Confirm email");
        }

        var errorList = isCreated.Errors.ToList();

        return Response<string>.Fail(errors: errorList.Select(e => e.Description).ToList());
    }
}