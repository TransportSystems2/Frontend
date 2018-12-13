namespace TransportSystems.Frontend.Core.Services.Interfaces.Settings
{
    public interface ISettingsService
    {
        bool HasKey(string key);

        string Get(string key);

        string Get(string key, string defKey);

        void Put(string key, string value);

        void Delete(string key);
    }
}
