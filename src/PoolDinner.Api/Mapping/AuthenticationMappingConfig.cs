using PoolDinner.Application.Authentication.Commands.Register;
using PoolDinner.Application.Authentication.Queries;
using PoolDinner.Application.Services.Authentication;
using PoolDinner.Contracts.Authentication;
using Mapster;

namespace PoolDinner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Following two Configs are redundant but its prefferred for the better code segregation and readability.
            // For an instance we need to add more configuration then we know that must be there in 'AuthenticationMappingConfig'
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            // Configuration for difference in Source and Destination object
            config.NewConfig<AuthenticationResult, AuthenticationResponse>().
                Map(desc => desc.Token, src => src.Token).
                Map(desc => desc.Id, src => src.user.Id.Value).
                Map(desc => desc, src => src.user);
        }
    }
}

