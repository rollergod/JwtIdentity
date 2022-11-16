using JwtIdentity.Api.Common.Mapping;
using JwtIdentity.Domain.IdentityModels;
using JwtIdentity.Persistance;
using Microsoft.AspNetCore.Identity;

namespace JwtIdentity.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddUiLayer(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddIdentityCore<User>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddMappings();
        return services;
    }
}