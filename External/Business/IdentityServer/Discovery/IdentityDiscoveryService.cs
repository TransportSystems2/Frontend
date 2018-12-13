using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Discovery;

namespace TransportSystems.Frontend.External.Business.IdentityServer.Discovery
{
    public class IdentityDiscoveryService : IIdentityDiscoveryService
    {
        public IdentityDiscoveryService(IIdentityConfig config)
        {
            Config = config;
        }

        protected IIdentityConfig Config { get; }

        private DiscoveryM Discovery { get; set; }

        public async Task<DiscoveryM> GetDiscovery()
        {
            if (Discovery == null)
            {
                Discovery = await GetRemoteDiscovery();
            }

            return Discovery;
        }

        public async Task<DiscoveryM> GetRemoteDiscovery()
        {
            DiscoveryM result = new DiscoveryM();
            using (var client = new HttpClient())
            {
                var discoveryDocument = new DiscoveryDocumentRequest
                {
                    Address = Config.Address
                };

                discoveryDocument.Policy.RequireHttps = false;
                var response = await client.GetDiscoveryDocumentAsync(discoveryDocument);
                if (response.IsError)
                {
                    throw new Exception(response.Error);
                }

                result = Mapper.Map<DiscoveryM>(response);
            }

            return result;
        }
    }
}
