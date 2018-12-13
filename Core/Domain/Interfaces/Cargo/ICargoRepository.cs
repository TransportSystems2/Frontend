using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Cargo
{
    public interface ICargoRepository
    {
        Task<CargoCatalogItemsDM> GetAvailableParams(RequestPriority priority);
    }
}
