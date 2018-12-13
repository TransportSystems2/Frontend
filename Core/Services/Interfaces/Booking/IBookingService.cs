using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Booking
{
    public interface IBookingService
    {
        Task<BookingResponseDM> Calculate(BookingRequestDM request, RequestPriority priority);
    }
}