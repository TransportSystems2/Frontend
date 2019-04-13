using System.Threading.Tasks;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Cargo;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Cargo;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Cargo
{
    public class CargoRepository : ApiRepository<ICargoAPI>, ICargoRepository
    {
        public CargoRepository(IAPIManager apiManager, IMappingService mappingService)
            : base(apiManager)
        {
            MappingService = mappingService;
        }

        protected IMappingService MappingService { get; }

        public async Task<CargoCatalogItemsDM> GetAvailableParams(RequestPriority priority)
        {
            var api = GetApi(priority);

            var externalParams = await api.GetAvailableParams();

            return MappingService.Map<CargoCatalogItemsDM>(externalParams);
        }

        public Task<bool> ValidateRegistrationNumber(string number, RequestPriority priority)
        {
            var api = GetApi(priority);

            return api.ValidRegistrationNumber(number);
        }
    }
}
