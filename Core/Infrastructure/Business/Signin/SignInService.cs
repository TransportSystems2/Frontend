using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.Core.Domain.Core.SignIn;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.SignOut;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Token;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Signin
{
    public class SignInService : ISignInService
    {
        public SignInService(IIdentityTokenService tokenService, IIdentityIntrospectionService introspectionService, ISignOutIdentityService signOutIdentityService, ISignInSettingsService signInSettingsService)
        {
            TokenService = tokenService;
            IntrospectionService = introspectionService;
            SignOutIdentityService = signOutIdentityService;
            SignInSettingsService = signInSettingsService;
        }

        protected IIdentityTokenService TokenService { get; }

        protected IIdentityIntrospectionService IntrospectionService { get; }

        protected ISignOutIdentityService SignOutIdentityService { get; }

        protected ISignInSettingsService SignInSettingsService { get; }

        public Task<bool> GetCodeAsync(string phone)
        {
            return TokenService.GetCode(phone);
        }

        public async Task<bool> AuthAsync(string phone, string code)
        {
            var token = await TokenService.GetToken(phone, code);
            if (token != null)
            {
                var domainToken = Mapper.Map<IdentityTokenDM>(token);
                SignInSettingsService.SaveIdentityToken(domainToken);
            }

            return token != null;
        }

        public Task<IdentityTokenDM> GetToken()
        {
            var token = SignInSettingsService.GetIdentityToken();

            return Task.FromResult(token);
        }

        public bool IsSigned()
        {
            return SignInSettingsService.ExistIdentityToken();
        }

        public async Task<bool> Check()
        {
            var result = SignInSettingsService.ExistIdentityToken();
            if (result)
            {
                var token = SignInSettingsService.GetIdentityToken();
                var introspectionResponse = await IntrospectionService.IntrospectToken(token.AccessToken);
                result = introspectionResponse.IsActive;
            }

            return result;
        }

        public async Task<IdentityTokenDM> RefreshToken(IdentityTokenDM oldToken)
        {
            var newToken = await TokenService.RefreshToken(oldToken.RefreshToken).ConfigureAwait(false);
            var domainToken = Mapper.Map<IdentityTokenDM>(newToken);
            SignInSettingsService.SaveIdentityToken(domainToken);

            return domainToken;
        }

        public async Task<bool> SignOut()
        {
            var result = SignInSettingsService.ExistIdentityToken();
            if (result)
            {
                var token = SignInSettingsService.GetIdentityToken();
                result = await SignOutIdentityService.SignOut(token.AccessToken);
            }

            return result;
        }
    }
}