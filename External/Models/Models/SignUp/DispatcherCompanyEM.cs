using TransportSystems.Frontend.External.Models.Geo;
using TransportSystems.Frontend.External.Models.Users;

namespace TransportSystems.Frontend.External.Models.SignUp
{
    public class DispatcherCompanyEM
    {
        public AddressEM GarageAddress { get; set; }

        public string CompanyName { get; set; }

        public DispatcherEM Dispatcher { get; set; }
    }
}