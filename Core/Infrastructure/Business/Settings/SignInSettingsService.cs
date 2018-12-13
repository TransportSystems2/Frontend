using TransportSystems.Frontend.Core.Domain.Core.SignIn;
using TransportSystems.Frontend.Core.Domain.Interfaces.Settings;
using TransportSystems.Frontend.Core.Domain.Interfaces.Utils;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Settings
{
    public class SignInSettingsService : SettingsService, ISignInSettingsService
    {
        private const string StorageName = "SignIn";

        private const string IdentityTokenKey = "IdentityToken";

        public SignInSettingsService(ISettingsRepository settingsRepository, IJsonConverter jsonSerializer)
            : base(settingsRepository)
        {
            JsonSerializer = jsonSerializer;
        }

        IJsonConverter JsonSerializer { get; }

        public bool ExistIdentityToken()
        {
            return HasKey(IdentityTokenKey);
        }

        public IdentityTokenDM GetIdentityToken()
        {
            var strToken = Get(IdentityTokenKey);

            return JsonSerializer.DeserializeObject<IdentityTokenDM>(strToken);
        }

        public void SaveIdentityToken(IdentityTokenDM token)
        {
            var strToken = JsonSerializer.SerializeObject(token);

            Put(IdentityTokenKey, strToken);
        }

        public void DeleteIdentityDoken()
        {
            Delete(IdentityTokenKey);
        }

        protected override string GetFileName()
        {
            return StorageName;
        }
    }
}
