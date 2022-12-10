using JwtIdentity.Domain.Common.Contracts.Response;
using Mapster;

namespace JwtIdentity.Api.Common.Mapping
{
    public class RegisterResponseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Response<string>, RegisterResponse>()
                .Map(dest => dest.ResponseMessage, source => source.Message);

            config.NewConfig<string, RegisterResponse>()
                .Map(dest => dest.Code, source => source);
        }
    }
}