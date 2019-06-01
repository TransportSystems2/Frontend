using System;
using TransportSystems.Frontend.Core.Domain.Core.Billing;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Core.Users;

namespace TransportSystems.Frontend.Core.Domain.Core.Booking
{
    // бронирование заказа
    public class BookingDM
    {
        public int MarketId { get; set; }

        public WaypointsDM Waypoints { get; set; }

        public DateTime TimeOfDelivery { get; set; }

        public CustomerDM Customer { get; set; }

        public CargoDM Cargo { get; set; }

        public BillDM Bill { get; set; }
    }
}
