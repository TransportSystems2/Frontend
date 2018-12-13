using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.SignOut;

namespace TransportSystems.Frontend.External.Business.IdentityServer.SignOut
{
    public class SignOutIdentityService : ISignOutIdentityService
    {
        public SignOutIdentityService(IIdentityDiscoveryService discoveryService, IIdentityIntrospectionService identityIntrospectionService, IIdentityConfig config)
        {
            DiscoveryService = discoveryService;
            IdentityIntrospectionService = identityIntrospectionService;
            Config = config;
        }

        protected IIdentityDiscoveryService DiscoveryService { get; }

        protected IIdentityIntrospectionService IdentityIntrospectionService { get; } 

        protected IIdentityConfig Config { get; }

        public async Task<bool> SignOut(string accessToken)
        {
            var result = false;
            var introspection = await IdentityIntrospectionService.IntrospectToken(accessToken);
            var discovery = await DiscoveryService.GetDiscovery();
            var requestUrl = new RequestUrl(discovery.AuthorizeEndpoint);
            var url = requestUrl.CreateAuthorizeUrl(Config.ClientId, "id_token", "openid email TSAPI");
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = response.StatusCode == System.Net.HttpStatusCode.OK;
            }

            return result;
        }
    }
}
