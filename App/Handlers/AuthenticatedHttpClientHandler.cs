using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ModernHttpClient;
using TransportSystems.Frontend.Core.Domain.Core.SignIn;

namespace TransportSystems.Frontend.App.Handlers
{
    public class AuthenticatedHttpClientHandler : NativeMessageHandler
    {
        private readonly Func<Task<IdentityTokenDM>> getToken;

        public AuthenticatedHttpClientHandler(Func<Task<IdentityTokenDM>> getToken)
        {
            this.getToken = getToken ?? throw new ArgumentNullException(nameof(getToken));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var token = await getToken().ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token.AccessToken);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
