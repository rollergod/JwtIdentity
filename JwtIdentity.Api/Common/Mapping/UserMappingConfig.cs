using JwtIdentity.Domain.Common.Contracts.DTO;
using JwtIdentity.Domain.IdentityModels;
using Mapster;

namespace JwtIdentity.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterModel, User>()
            .Map(dest => dest.DisplayName, src => src.NickName)
            .Map(dest => dest.UserName, src => src.Name)
            .Map(dest => dest.EmailConfirmed, src => src.ConfirmedEmail)
            .Map(dest => dest, src => src);
    }
}