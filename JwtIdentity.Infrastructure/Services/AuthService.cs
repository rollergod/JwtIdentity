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

    public async Task<Response<LoginResponse>> Login(string email, string password)
    {
        var isUserExist = await _userManager.FindByEmailAsync(email);

        if (isUserExist == null)
            return Response<LoginResponse>.Fail("User doesnt exist");

        if (!isUserExist.EmailConfirmed)
            return Response<LoginResponse>.Fail("User doesnt confirm his email");

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(isUserExist, password);

        if (!isPasswordCorrect)
            return Response<LoginResponse>.Fail("Users password isn`t correct");

        var token = _jwtTokenGenerator.GenerateToken(isUserExist);

        var tokenResponse = _mapper.Map<LoginResponse>((isUserExist, token));

        return Response<LoginResponse>.Success(
            data: tokenResponse,
            message: "Successful authorization"
        );
    }

    public async Task<Response<RegisterResponse>> Register(User model, string password)
    {
        var isUserExist = await _userManager.FindByEmailAsync(model.Email);

        if (isUserExist != null)
            return Response<RegisterResponse>.Fail("User is existing");

        var isCreated = await _userManager.CreateAsync(model, password);

        if (isCreated.Succeeded)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(model);

            var registerResponse = _mapper.Map<RegisterResponse>(code);

            return Response<RegisterResponse>.Success(
                data: registerResponse,
                message: "User registered successfully. Confirm email");
        }

        var errorList = isCreated.Errors.ToList();

        return Response<RegisterResponse>.Fail(errors: errorList.Select(e => e.Description).ToList());
    }
}