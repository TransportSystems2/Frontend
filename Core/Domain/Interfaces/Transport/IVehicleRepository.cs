using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Transport;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Transport
{
    public interface IVehicleRepository
    {
        Task<VehicleParametersDM> GetVehiclesParams(RequestPriority priority);
    }
}