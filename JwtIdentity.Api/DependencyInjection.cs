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

        services.AddIdentityCore<User>(opt => opt.SignIn.RequireConfirmedEmail = false)
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequiredLength = 5;
            opt.Password.RequiredUniqueChars = 0;
            opt.Password.RequireNonAlphanumeric = false;
        });

        services.AddMappings();
        return services;
    }
}