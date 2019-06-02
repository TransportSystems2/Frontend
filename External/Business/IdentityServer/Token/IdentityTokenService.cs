using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Token;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Token;

namespace TransportSystems.Frontend.External.Business.IdentityServer.Token
{
    public class IdentityTokenService : IIdentityTokenService
    {
        public IdentityTokenService(IIdentityDiscoveryService discoveryService, IIdentityConfig config)
        {
            DiscoveryService = discoveryService;
            Config = config;
        }

        protected IIdentityDiscoveryService DiscoveryService { get; }

        protected IIdentityConfig Config { get; }

        public async Task<bool> GetCode(string phone)
        {
            var result = false;

            using (var client = new HttpClient())
            {
                var phoneJsonModel = $"'phone': {phone}";
                var json = @"{" + phoneJsonModel + "}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var discovery = await DiscoveryService.GetDiscovery();
                var response = await client.PostAsync(discovery.SendCodeEndpoint, content).ConfigureAwait(false);

                result = response.StatusCode == HttpStatusCode.Accepted;
            }

            return result;
        }

        public async Task<TokenM> GetToken(string phone, string code)
        {
            var result = new TokenM();
            using (var client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                    { "phone_number", phone },
                    { "verification_token", code }
                };

                var discovery = await DiscoveryService.GetDiscovery();
                var response = await client.RequestTokenAsync(new TokenRequest
                {
                    Address = discovery.TokenEndpoint,
                    GrantType = Config.GrandType,
                    ClientId = Config.ClientId,
                    ClientSecret = Config.ClientSecret,
                    Parameters = parameters
                });

                if (response.IsError)
                {
                    throw new Exception(response.Error);
                }

                result = Mapper.Map<TokenM>(response);
            }

            return result;
        }

        public async Task<TokenM> RefreshToken(string refreshToken)
        {
            var result = new TokenM();
            using (var client = new HttpClient())
            {
                var discovery = await DiscoveryService.GetDiscovery();
                var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = discovery.TokenEndpoint,
                    ClientId = Config.ClientId,
                    ClientSecret = Config.ClientSecret,
                    RefreshToken = refreshToken
                });

                if (response.IsError)
                {
                    throw new Exception(response.Error);
                }

                result = Mapper.Map<TokenM>(response);
            }

            return result;
        }
    }
}
