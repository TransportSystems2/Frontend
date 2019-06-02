using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.Users;

namespace TransportSystems.Frontend.Core.Domain.Core.SignUp
{
    public class DispatcherCompanyDM
    {
        public AddressDM GarageAddress { get; set; }

        public string CompanyName { get; set; }

        public DispatcherDM Dispatcher { get; set; }
    }
}