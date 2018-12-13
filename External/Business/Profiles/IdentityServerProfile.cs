using AutoMapper;
using IdentityModel.Client;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Token;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.UserInfo;

namespace TransportSystems.Frontend.External.Business.Profiles
{
    public class IdentityServerProfile : Profile
    {
        public IdentityServerProfile()
        {
            CreateMap<DiscoveryResponse, DiscoveryM>();
            CreateMap<IntrospectionResponse, IntrospectionM>();
            CreateMap<TokenResponse, TokenM>();
            CreateMap<UserInfoResponse, UserInfoM>();
        }
    }
}