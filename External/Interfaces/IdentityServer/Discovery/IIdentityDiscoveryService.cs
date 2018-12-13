using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Discovery;

namespace TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery
{
    public interface IIdentityDiscoveryService
    {
        Task<DiscoveryM> GetDiscovery();
    }
}