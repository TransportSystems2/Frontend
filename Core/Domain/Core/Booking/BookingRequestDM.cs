using TransportSystems.Frontend.Core.Domain.Core.Billing;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Core.Transport;

namespace TransportSystems.Frontend.Core.Domain.Core.Booking
{
    public class BookingRequestDM
    {
		public BookingRequestDM()
		{
			Waypoints = new WaypointsDM();
            Basket = new BasketDM();
            Cargo = new CargoDM();
		}

        public WaypointsDM Waypoints { get; set; }

        public BasketDM Basket { get; set; }

        public CargoDM Cargo { get; set; }
    }
}
