using TransportSystems.Frontend.External.Models.Models.Billing;
using TransportSystems.Frontend.External.Models.Models.Routing;
using TransportSystems.Frontend.External.Models.Models.Transport;

namespace TransportSystems.Frontend.External.Models.Models.Booking
{
    public class BookingRequestEM
    {
        public WaypointsEM Waypoints { get; set; }

        public BasketEM Basket { get; set; }

        public CargoEM Cargo { get; set; }
    }
}
