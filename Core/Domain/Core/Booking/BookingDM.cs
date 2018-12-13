using System;
using TransportSystems.Frontend.Core.Domain.Core.Billing;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Core.Users;

namespace TransportSystems.Frontend.Core.Domain.Core.Booking
{
    public class BookingDM
    {
        public AddressDM RootAddress { get; set; }

        public WaypointsDM Waypoints { get; set; }

        public DateTime OrderTime { get; set; }

        public CustomerDM Customer { get; set; }

        public CargoDM Cargo { get; set; }

        public BillInfoDM BillInfo { get; set; }

        public BasketDM Basket { get; set; }
    }
}
