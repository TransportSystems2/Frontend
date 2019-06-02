using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Address;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Address
{
    public class AddressService : IAddressService
    {
        public AddressService(IAddressRepository repository)
        {
            Repository = repository;
        }

        protected IAddressRepository Repository { get; }

        public Task<ICollection<AddressDM>> GetAddresses(string request, RequestPriority priority)
        {
            return Repository.GetAddresses(request, priority);
        }

        public Task<ICollection<AddressDM>> GetAddressesByCoordinate(double latitude, double longitude, RequestPriority priority)
        {
            return Repository.GetAddressesByCoordinate(latitude, longitude, priority);
        }
    }
}