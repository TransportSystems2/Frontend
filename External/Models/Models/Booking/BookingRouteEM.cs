using System;
using DotNetDistance;
using TransportSystems.Frontend.External.Models.Models.Billing;

namespace TransportSystems.Frontend.External.Models.Models.Booking
{
    public class BookingRouteEM
    {
        public string Title { get; set; }

        public int MarketId { get; set; }

        public TimeBeltEM MarketTimeBelt { get; set; }

        public Distance TotalDistance { get; set; }

        public Distance FeedDistance { get; set; }

        public TimeSpan AvgDeliveryTime { get; set; }

        public BillEM Bill { get; set; }
    }
}
