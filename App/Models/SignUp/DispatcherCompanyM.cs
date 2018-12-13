using TransportSystems.Frontend.App.Models.Geo;
using TransportSystems.Frontend.App.Models.Users;

namespace TransportSystems.Frontend.App.Models.SignUp
{
    public class DispatcherCompanyM
    {
        public AddressM GarageAddress { get; set; }

        public string CompanyName { get; set; }

        public DispatcherM Dispatcher { get; set; }
    }
}
