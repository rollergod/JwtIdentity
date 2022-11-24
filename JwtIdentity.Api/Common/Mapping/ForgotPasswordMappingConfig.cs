using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;

namespace JwtIdentity.Api.Common.Mapping;

public class ForgotPasswordMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(User user, string token), ForgotPasswordCodeResponse>()
            .Map(dest => dest.Code, src => src.token)
            .Map(dest => dest.User, src => src.user);
    }
}