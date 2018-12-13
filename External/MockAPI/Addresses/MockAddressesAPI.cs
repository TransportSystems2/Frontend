using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Interfaces.Addresses;
using TransportSystems.Frontend.External.Models.Geo;

namespace TransportSystems.Frontend.External.MockAPI.Addresses
{
    public class MockAddressesAPI : IAddressesAPI
    {
        public MockAddressesAPI()
            : this(0)
        {
        }

        public MockAddressesAPI(int delay)
        {
            Delay = delay;
        }

        protected int Delay { get; }

        public async Task<ICollection<AddressEM>> GetAddress(string request)
        {
            await Task.Delay(Delay);

            ICollection<AddressEM> result = new List<AddressEM>
            {
                new AddressEM
                {
                    Country = "Россия",
                    Province = "Ярославская область",
                    Area = "городской округ Рыбинск",
                    Locality = "Рыбинск",
                    District = null,
                    Street = "улица 9 Мая",
                    House = "7",
                    Request = null,
                    FormattedText = null,
                    Latitude = 58.053755,
                    Longitude = 58.053755,
                    AdjustedLatitude = 0,
                    AdjustedLongitude = 0
                }
            };

            return result;
        }

        public async Task<ICollection<AddressEM>> GetAddressByCoordinate(double latitude, double longitude)
        {
            await Task.Delay(Delay);

            ICollection<AddressEM> result = new List<AddressEM>
            {
                new AddressEM
                {
                    Country = "Россия",
                    Province = "Ярославская область",
                    Area = "городской округ Рыбинск",
                    Locality = "Рыбинск",
                    District = null,
                    Street = "улица 9 Мая",
                    House = "7",
                    Request = null,
                    FormattedText = null,
                    Latitude = latitude,
                    Longitude = longitude,
                    AdjustedLatitude = 0,
                    AdjustedLongitude = 0
                }
            };

            return result;
        }
    }
}
