using Microsoft.EntityFrameworkCore;

namespace JwtIdentity.Application.Common.Interfaces;

public interface IAppDbContext
{
    Task<int> SaveChangesAsync();
}