using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Core.Users;

namespace TransportSystems.Frontend.Core.Domain.Core.SignUp
{
    public class DriverCompanyDM
    {
        public AddressDM GarageAddress { get; set; }

        public string CompanyName { get; set; }

        public DriverDM Driver { get; set; }

        public VehicleDM Vehicle { get; set; }
    }
}