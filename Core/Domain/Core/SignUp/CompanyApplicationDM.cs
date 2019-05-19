using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.Transport;

namespace TransportSystems.Frontend.Core.Domain.Core.SignUp
{
    public class CompanyApplicationDM
    {
        public DispatcherDM Dispatcher { get; set; }

        public AddressDM GarageAddress { get; set; }

        public VehicleDM Vehicle { get; set; }

        public DriverDM Driver { get; set; }
    }
}