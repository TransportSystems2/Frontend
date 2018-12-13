using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Interfaces.Transport;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Transport;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Transport
{
    public class VehicleRepository : ApiRepository<IVehicleAPI>, IVehicleRepository
    {
        public VehicleRepository(IAPIManager apiManager)
            : base(apiManager)
        {
        }

        public async Task<VehicleParametersDM> GetVehiclesParams(RequestPriority priority)
        {
            var result = new VehicleParametersDM();

            var api = GetApi(priority);
            var vehicleParams = await api.GetVehicleParams();

            Mapper.Map(vehicleParams, result);

            return result;
        }
    }
}