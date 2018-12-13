using TransportSystems.Frontend.Core.Domain.Core.SignIn;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Settings
{
    public interface ISignInSettingsService
    {
        bool ExistIdentityToken();

        IdentityTokenDM GetIdentityToken();

        void SaveIdentityToken(IdentityTokenDM token);

        void DeleteIdentityDoken();
    }
}