using JwtIdentity.Application.Common.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtIdentity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAppLayer(this IServiceCollection services,
                                                 IConfiguration configuration)
    {
        services.Configure<EmailConfig>(configuration.GetSection($"{EmailConfig.SectionName}"));

        return services;
    }
}