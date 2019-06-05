using TransportSystems.Frontend.External.Models.Geo;
using TransportSystems.Frontend.External.Models.Transport;
using TransportSystems.Frontend.External.Models.Users;

namespace TransportSystems.Frontend.External.Models.SignUp
{
    public class CompanyApplicationEM
    {
        public DispatcherEM Dispatcher { get; set; }

        public AddressEM GarageAddress { get; set; }

        public VehicleEM Vehicle { get; set; }

        public DriverEM Driver { get; set; }
    }
}