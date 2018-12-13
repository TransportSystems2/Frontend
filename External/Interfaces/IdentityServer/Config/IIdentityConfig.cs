namespace TransportSystems.Frontend.External.Interfaces.IdentityServer.Config
{
    public interface IIdentityConfig
    {
        string Address { get; }

        string GrandType { get; }

        string ClientId { get; }

        string ClientSecret { get; }

        string ApiName { get; }
    }
}