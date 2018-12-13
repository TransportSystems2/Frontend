using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Cargo
{
    public interface ICargoService
    {
        Task<CargoCatalogItemsDM> GetAvailableParams(RequestPriority priority);
    }
}
