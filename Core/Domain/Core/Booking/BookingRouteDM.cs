using TransportSystems.Frontend.Core.Domain.Core.Billing;
using TransportSystems.Frontend.Core.Domain.Core.Geo;

namespace TransportSystems.Frontend.Core.Domain.Core.Booking
{
    public class BookingRouteDM
    {
        public string Title { get; set; }

        public AddressDM RootAddress { get; set; }

        public int TotalDistance { get; set; }

        public int FeedDistance { get; set; }

        public int FeedDuration { get; set; }

        public BillDM Bill { get; set; }
    }
}
