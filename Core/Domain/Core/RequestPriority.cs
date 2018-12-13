namespace TransportSystems.Frontend.Core.Domain.Core
{
    public enum RequestPriority
    {
        Speculative = 10,
        UserInitiated = 100,
        Background = 20,
        Explicit = 0
    }
}
