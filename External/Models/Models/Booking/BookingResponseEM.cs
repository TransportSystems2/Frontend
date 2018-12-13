using System.Collections.Generic;

namespace TransportSystems.Frontend.External.Models.Models.Booking
{
    public class BookingResponseEM
    {
        public BookingResponseEM()
        {
            Routes = new List<BookingRouteEM>();
        }

        public List<BookingRouteEM> Routes { get; set; }
    }
}
