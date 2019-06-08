using System;
using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.External.Business.IdentityServer.Config;
using TransportSystems.Frontend.External.Business.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Business.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Business.IdentityServer.Token;
using TransportSystems.Frontend.External.Business.IdentityServer.UserInfo;
using TransportSystems.Frontend.External.Business.Profiles;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Token;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.UserInfo;

namespace Client
{
    public class Program
    {
        private const string IdentityUri = "http://localhost:54420/";
        private const string GrandType = "phone_number_token";
        private const string ClientId = "phone_number_authentication";
        private const string ClientSecret = "secret";
        private const string ApiName = "TSAPI";

        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();
        
        private static async Task MainAsync()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<IdentityServerProfile>();
            });

            IIdentityConfig config = new IdentityConfig(IdentityUri, GrandType, ClientId, ClientSecret, ApiName);
            IIdentityDiscoveryService discoveryService = new IdentityDiscoveryService(config);
            IIdentityTokenService tokenService = new IdentityTokenService(discoveryService, config);
            IIdentityIntrospectionService introspectionService = new IdentityIntrospectionService(discoveryService, config);
            IIdentityUserInfoService userInfoService = new IdentityUserInfoService(discoveryService);

            var phone = "79159771817";
            await tokenService.GetCode(phone);

            Console.WriteLine("Code was sended, enter please");
            var code = Console.ReadLine();

            var token = await tokenService.GetToken(phone, code);
            var refreshedToken = await tokenService.RefreshToken(token.RefreshToken);
            var introspectionResponse = await introspectionService.IntrospectToken(refreshedToken.AccessToken);
            var userInfo = await userInfoService.GetUserInfo(refreshedToken.AccessToken);
        }
    }
}