using System;
using System.Threading.Tasks;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Interfaces.Booking;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Booking;
using TransportSystems.Frontend.External.Models.Models.Booking;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Booking
{
    public class BookingRepository : ApiRepository<IBookingAPI>, IBookingRepository
    {
        public BookingRepository(IAPIManager apiManager, IMappingService mappingService) : base(apiManager)
        {
            MappingService = mappingService;
        }

        protected IMappingService MappingService { get; }

        public async Task<BookingResponseDM> Calculate(BookingRequestDM request, RequestPriority priority)
        {
            var api = GetApi(priority);

            var externalRequest = MappingService.Map<BookingRequestEM>(request);
            var externalResponse = await api.Calculate(externalRequest);

            return MappingService.Map<BookingResponseDM>(externalResponse);
        }
    }
}
