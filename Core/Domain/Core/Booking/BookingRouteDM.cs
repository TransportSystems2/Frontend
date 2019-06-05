using System;
using DotNetDistance;
using TransportSystems.Frontend.Core.Domain.Core.Billing;

namespace TransportSystems.Frontend.Core.Domain.Core.Booking
{
    public class BookingRouteDM
    {
        public string Title { get; set; }

        public int MarketId { get; set; }

        // Часовой пояс биржи
        public TimeBeltDM MarketTimeBelt { get; set; }

        public Distance TotalDistance { get; set; }

        public Distance FeedDistance { get; set; }

        public TimeSpan AvgDeliveryTime { get; set; }

        public BillDM Bill { get; set; }
    }
}