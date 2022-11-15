using JwtIdentity.Application.Common.Interfaces;
using JwtIdentity.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtIdentity.Persistance;

public class AppDbContext : IdentityDbContext<User>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    { }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}