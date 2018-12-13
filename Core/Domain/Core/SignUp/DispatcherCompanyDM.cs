using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Domain.Core.Geo;

namespace TransportSystems.Frontend.Core.Domain.Core.SignUp
{
    public class DispatcherCompanyDM
    {
        public AddressDM GarageAddress { get; set; }

        public string CompanyName { get; set; }

        public DispatcherDM Dispatcher { get; set; }
    }
}