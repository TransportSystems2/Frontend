using TransportSystems.Frontend.Core.Domain.Interfaces.Settings;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Settings
{
    public abstract class SettingsService : ISettingsService
    {
        public SettingsService(ISettingsRepository settingsRepository)
        {
            SettingsRepository = settingsRepository;
        }

        private ISettingsRepository SettingsRepository { get; }

        private string FileName => GetFileName();

        public bool HasKey(string key)
        {
            var defValue = "defValue";
            var value = SettingsRepository.GetValueOrDefault(key, defValue, FileName);

            return !defValue.Equals(value);
        }

        public string Get(string key)
        {
            return SettingsRepository.GetValueOrDefault(key, string.Empty, FileName);
        }

        public string Get(string key, string defKey)
        {
            return SettingsRepository.GetValueOrDefault(key, defKey, FileName);
        }

        public void Put(string key, string value)
        {
            SettingsRepository.AddOrUpdateValue(key, value, FileName);
        }

        public void Delete(string key)
        {
            SettingsRepository.Remove(key, FileName);
        }

        protected abstract string GetFileName();
    }
}