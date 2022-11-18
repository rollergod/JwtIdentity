using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using JwtIdentity.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JwtIdentity.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _context;

    public UserService(UserManager<User> userManager,
                       AppDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<Response<ICollection<User>>> GetAllUsers()
    {
        var result = await _userManager.Users.ToListAsync();

        var test = await _context.Users.ToListAsync();

        if (result == null || result.Count == 0)
            return Response<ICollection<User>>.Fail("There aren`t authorized users");

        return Response<ICollection<User>>.Success(
            data: result,
            message: "successfully"
        );
    }
}