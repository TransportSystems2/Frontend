using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.Transport;

namespace TransportSystems.Frontend.External.Transport
{
    public interface IVehicleAPI
    {
        [Headers("Authorization: Bearer")]
        [Get("/api/vehicles/catalog_items")]
        Task<VehicleParametersEM> GetVehicleParams();
    }
}
