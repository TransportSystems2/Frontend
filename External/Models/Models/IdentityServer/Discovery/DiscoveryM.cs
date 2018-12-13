using System.Collections.Generic;

namespace TransportSystems.Frontend.External.Models.Models.IdentityServer.Discovery
{
    public class DiscoveryM
    {
        public string Issuer { get; set; }

        public string JwksUri { get; set; }

        public string AuthorizeEndpoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string UserinfoEndpoint { get; set; }

        public string EndSessionEndpoint { get; set; }

        public string CheckSessionIframe { get; set; }

        public string RevocationEndpoint { get; set; }

        public string IntrospectionEndpoint { get; set; }

        public bool FrontchannelLogoutSupported { get; set; }

        public bool FrontchannelLogoutSessionSupported { get; set; }

        public bool BackchannelLogoutSupported { get; set; }

        public bool BackchannelLogoutSessionSupported { get; set; }

        public ICollection<string> ScopesSupported { get; set; }

        public ICollection<string> ClaimsSupported { get; set; }

        public ICollection<string> GrantTypesSupported { get; set; }

        public ICollection<string> ResponseTypesSupported { get; set; }

        public ICollection<string> ResponseModesSupported { get; set; }

        public ICollection<string> TokenEndpointAuthMethodsSupported { get; set; }

        public ICollection<string> SubjectTypesSupported { get; set; }

        public ICollection<string> IdTokenSigningAlgValuesSupported { get; set; }

        public ICollection<string> CodeChallengeMethodsSupported { get; set; }
    }
}
