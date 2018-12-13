using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.Geo;

namespace TransportSystems.Frontend.External.Interfaces.Addresses
{
    public interface IAddressesAPI
    {
        [Get("/api/addresses/geocode")]
        [Headers("Authorization: Bearer")]
        Task<ICollection<AddressEM>> GetAddress(string request);

        [Get("/api/addresses/reverse_geocode")]
        [Headers("Authorization: Bearer")]
        Task<ICollection<AddressEM>> GetAddressByCoordinate(double latitude, double longitude);
    }
}
