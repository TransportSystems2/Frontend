using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Interfaces.Utils;
using TransportSystems.Frontend.External.Models.SignIn;
using TransportSystems.Frontend.External.SignIn;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Rest.SignIn
{
    public class SignInAPI : ISignInAPI
    {
        private const string IdentityUri = "http://localhost:54420/";
        private const string GrandType = "phone_number_token";
        private const string ClientId = "phone_number_authentication";
        private const string ClientSecret = "secret";
        private const string ApiName = "TSAPI";

        public SignInAPI(IJsonConverter jsonConverter)
        {
            JsonConverter = jsonConverter;
            Client = new HttpClient();
        }

        private IJsonConverter JsonConverter { get; }

        private HttpClient Client { get; }

        public async Task<bool> CheckToken(IdentityTokenEM token)
        {
            var dict = new Dictionary<string, string>
            {
                { "client_id", ApiName },
                { "client_secret", ClientSecret },
                { "token", token.AccessToken }
            };

            var uri = Path.Combine(IdentityUri, "connect/introspect");
            var content = new FormUrlEncodedContent(dict);
            var response = await Client.PostAsync(uri, content).ConfigureAwait(false);

            var success = response.StatusCode == HttpStatusCode.OK;
            if (!success)
            {
                return false;
            }

            var strTokenInfo = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var tokenInfo = JsonConverter.DeserializeObject<InfoTokenModelEM>(strTokenInfo);

            return tokenInfo.Active;
        }
    }
}
