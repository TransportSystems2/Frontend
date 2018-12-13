using System.Collections.Generic;

namespace TransportSystems.Frontend.Core.Domain.Core.Booking
{
    public class BookingResponseDM
    {
        public BookingResponseDM()
        {
            Routes = new List<BookingRouteDM>();
        }

        public List<BookingRouteDM> Routes { get; set; }
    }
}
