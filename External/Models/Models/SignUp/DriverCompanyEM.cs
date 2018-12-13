using TransportSystems.Frontend.External.Models.Geo;
using TransportSystems.Frontend.External.Models.Transport;
using TransportSystems.Frontend.External.Models.Users;

namespace TransportSystems.Frontend.External.Models.SignUp
{
    public class DriverCompanyEM
    {
        public AddressEM GarageAddress { get; set; }

        public string CompanyName { get; set; }

        public DriverEM Driver { get; set; }

        public VehicleEM Vehicle { get; set; }
    }
}