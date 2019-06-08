using TransportSystems.Frontend.App.Models.Geo;
using TransportSystems.Frontend.App.Models.Transport;
using TransportSystems.Frontend.App.Models.Users;

namespace TransportSystems.Frontend.App.Models.SignUp
{
    public class CompanyApplicationM
    {
        public DispatcherM Dispatcher { get; set; }

        public AddressM GarageAddress { get; set; }

        public VehicleM Vehicle { get; set; }

        public DriverM Driver { get; set; }
    }
}