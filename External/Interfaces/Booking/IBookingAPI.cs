using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.Models.Booking;

namespace TransportSystems.Frontend.External.Interfaces.Booking
{
    public interface IBookingAPI
    {
        [Post("/api/booking")]
        [Headers("Authorization: Bearer")]
        Task<BookingResponseEM> Calculate(BookingRequestEM request);
    }
}
