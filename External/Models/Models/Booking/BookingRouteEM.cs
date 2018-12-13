using TransportSystems.Frontend.External.Models.Geo;
using TransportSystems.Frontend.External.Models.Models.Billing;

namespace TransportSystems.Frontend.External.Models.Models.Booking
{
    public class BookingRouteEM
    {
        public string Title { get; set; }

        public AddressEM RootAddress { get; set; }

        public int TotalDistance { get; set; }

        public int FeedDistance { get; set; }

        public int FeedDuration { get; set; }

        public BillEM Bill { get; set; }
    }
}
