using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Interfaces.Transport;
using TransportSystems.Frontend.Core.Services.Interfaces.Transport;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Transport
{
    public class VehicleService : IVehicleService
    {
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            Repository = vehicleRepository;
        }

        protected IVehicleRepository Repository { get; }

        public Task<VehicleParametersDM> GetVehiclesParams(RequestPriority priority)
        {
            return Repository.GetVehiclesParams(priority);
        }
    }
}