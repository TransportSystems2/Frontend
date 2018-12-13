using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Introspection;

namespace TransportSystems.Frontend.External.Business.IdentityServer.Introspection
{
    public class IdentityIntrospectionService : IIdentityIntrospectionService
    {
        public IdentityIntrospectionService(IIdentityDiscoveryService discoveryService, IIdentityConfig config)
        {
            DiscoveryService = discoveryService;
            Config = config;
        }

        protected IIdentityDiscoveryService DiscoveryService { get; }

        protected IIdentityConfig Config { get; }

        public async Task<IntrospectionM> IntrospectToken(string accessToken)
        {
            var result = new IntrospectionM();
            using (var client = new HttpClient())
            {
                var discovery = await DiscoveryService.GetDiscovery();
                var response = await client.IntrospectTokenAsync(new TokenIntrospectionRequest
                {
                    Address = discovery.IntrospectionEndpoint,
                    ClientId = Config.ApiName,
                    ClientSecret = Config.ClientSecret,
                    Token = accessToken
                });

                if (response.IsError)
                {
                    throw new Exception(response.Error);
                }

                result = Mapper.Map<IntrospectionM>(response);
            }

            return result;
        }
    }
}