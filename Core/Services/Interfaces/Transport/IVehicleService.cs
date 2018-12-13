using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Transport;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Transport
{
    public interface IVehicleService
    {
        Task<VehicleParametersDM> GetVehiclesParams(RequestPriority priority);
    }
}
