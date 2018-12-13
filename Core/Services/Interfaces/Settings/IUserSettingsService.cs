namespace TransportSystems.Frontend.Core.Services.Interfaces.Settings
{
    public interface IUserSettingsService
    {
        string GetName();

        string GetLastName();

        void SaveName(string name);

        void SaveLastName(string lastName);
    }
}