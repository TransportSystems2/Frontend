using TransportSystems.Frontend.External.Models.Models;

namespace TransportSystems.Frontend.External.Interfaces
{
    public interface IAPIManager
    {
        T Get<T>(RequestPriority priority);
    }
}