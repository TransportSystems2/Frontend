using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Booking
{
    public interface IBookingRepository
    {
        Task<BookingResponseDM> Calculate(BookingRequestDM request, RequestPriority priority);
    }
}
