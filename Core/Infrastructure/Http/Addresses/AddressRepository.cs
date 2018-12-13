using System.Collections.Generic;
using System.Threading.Tasks;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Address;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Addresses;
using TransportSystems.Frontend.External.Models.Geo;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Addresses
{
    public class AddressRepository : ApiRepository<IAddressesAPI>, IAddressRepository
    {
        public AddressRepository(IAPIManager apiManager, IMappingService mappingService)
            : base(apiManager)
        {
            MappingService = mappingService;
        }

        protected IMappingService MappingService {get;}

        public async Task<ICollection<AddressDM>> GetAddresses(string request, RequestPriority priority)
        {
            var api = GetApi(priority);

            var addresses = await api.GetAddress(request);

            return MappingService.Map<ICollection<AddressEM>, ICollection<AddressDM>>(addresses);
        }

        public async Task<ICollection<AddressDM>> GetAddressesByCoordinate(double latitude, double longitude, RequestPriority priority)
        {
            var api = GetApi(priority);

            var addresses = await api.GetAddressByCoordinate(latitude, longitude);

            return MappingService.Map<ICollection<AddressEM>, ICollection<AddressDM>>(addresses);
        }
    }
}
