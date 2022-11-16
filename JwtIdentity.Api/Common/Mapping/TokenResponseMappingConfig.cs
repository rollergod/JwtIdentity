using JwtIdentity.Domain.Common.Contracts.Response;
using JwtIdentity.Domain.IdentityModels;
using Mapster;

namespace JwtIdentity.Api.Common.Mapping;

public class TokenResponseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(User isUserExist, string token), TokenResponse>()
            .Map(dest => dest.Token, src => src.token)
            .Map(dest => dest, src => src.isUserExist);
    }
}