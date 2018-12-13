using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.UserInfo;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.UserInfo;

namespace TransportSystems.Frontend.External.Business.IdentityServer.UserInfo
{
    public class IdentityUserInfoService : IIdentityUserInfoService
    {
        public IdentityUserInfoService(IIdentityDiscoveryService discoveryService)
        {
            DiscoveryService = discoveryService;
        }

        protected IIdentityDiscoveryService DiscoveryService { get; }

        public async Task<UserInfoM> GetUserInfo(string token)
        {
            UserInfoM result = null;
            using (var client = new HttpClient())
            {
                var discovery = await DiscoveryService.GetDiscovery();
                var response = await client.GetUserInfoAsync(new UserInfoRequest
                {
                    Address = discovery.UserinfoEndpoint,
                    Token = token
                });

                if (response.IsError)
                {
                    throw new Exception(response.Error);
                }

                result = Mapper.Map<UserInfoM>(response);
            }

            return result;
        }
    }
}