using System;
using TransportSystems.Frontend.External.Models.Models.Billing;
using TransportSystems.Frontend.External.Models.Models.Routing;
using TransportSystems.Frontend.External.Models.Models.Transport;
using TransportSystems.Frontend.External.Models.Users;

namespace TransportSystems.Frontend.External.Models.Models.Booking
{
    public class BookingEM
    {
        public int MarketId { get; set; }

        public WaypointsEM Waypoints { get; set; }

        public DateTime TimeOfDelivery { get; set; }

        public CustomerEM Customer { get; set; }

        public CargoEM Cargo { get; set; }

        public BillEM Bill { get; set; }
    }
}
