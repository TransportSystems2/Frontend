using TransportSystems.Frontend.Core.Domain.Interfaces.Settings;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Settings
{
    public class UserSettingsService : SettingsService, IUserSettingsService
    {
        private const string StorageName = "UserSettings";

        private const string FirstNameKey = "FirstNameKey";
        private const string LastNameKey = "LastNameKey";

        public UserSettingsService(ISettingsRepository settingsRepository)
            : base(settingsRepository)
        {
        }

        public string GetName()
        {
            return Get(FirstNameKey);
        }

        public string GetLastName()
        {
            return Get(LastNameKey);
        }

        public void SaveName(string name)
        {
            Put(FirstNameKey, name);
        }

        public void SaveLastName(string lastName)
        {
            Put(LastNameKey, lastName);
        }

        protected override string GetFileName()
        {
            return StorageName;
        }
    }
}