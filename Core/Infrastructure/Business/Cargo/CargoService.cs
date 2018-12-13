using System;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Cargo;
using TransportSystems.Frontend.Core.Services.Interfaces.Cargo;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Cargo
{
    public class CargoService : ICargoService
    {
        public CargoService(ICargoRepository cargoRepository)
        {
            CargoRepository = cargoRepository;
        }

        protected ICargoRepository CargoRepository { get; }

        public Task<CargoCatalogItemsDM> GetAvailableParams(RequestPriority priority)
        {
            return CargoRepository.GetAvailableParams(priority);
        }
    }
}
