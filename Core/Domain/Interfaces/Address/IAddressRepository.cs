using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Address
{
    public interface IAddressRepository
    {
        Task<ICollection<AddressDM>> GetAddresses(string request, RequestPriority priority);

        Task<ICollection<AddressDM>> GetAddressesByCoordinate(double latitude, double longitude, RequestPriority priority);
    }
}