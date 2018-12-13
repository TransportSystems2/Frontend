using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Interfaces.Booking;
using TransportSystems.Frontend.Core.Services.Interfaces.Booking;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Booking
{
    public class BookingService : IBookingService
    {
        public BookingService(IBookingRepository bookingRepository)
        {
            BookingRepository = bookingRepository;
        }

        protected IBookingRepository BookingRepository { get; }

        public Task<BookingResponseDM> Calculate(BookingRequestDM request, RequestPriority priority)
        {
            return BookingRepository.Calculate(request, priority);
        }
    }
}
