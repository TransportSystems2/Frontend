using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;

namespace TransportSystems.Frontend.External.Business.IdentityServer.Config
{
    public class IdentityConfig : IIdentityConfig
    {
        public IdentityConfig(
            string address,
            string grandType,
            string clientId,
            string clientSecret,
            string apiName)
        {
            Address = address;
            GrandType = grandType;
            ClientId = clientId;
            ClientSecret = clientSecret;
            ApiName = apiName;
        }

        public string Address { get; }

        public string GrandType { get; }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string ApiName { get; }
    }
}
