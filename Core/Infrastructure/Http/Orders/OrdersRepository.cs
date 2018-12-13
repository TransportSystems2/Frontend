using System;
using System.Threading.Tasks;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Interfaces.Orders;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Orders;
using TransportSystems.Frontend.External.Models.Models.Booking;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Orders
{
    public class OrdersRepository : ApiRepository<IOrdersAPI>, IOrdersRepository
    {
        public OrdersRepository(IAPIManager apiManager, IMappingService mappingService)
            : base(apiManager)
        {
            MappingService = mappingService;
        }

        protected IMappingService MappingService { get; }

        public async Task Create(BookingDM booking, RequestPriority priority)
        {
            var api = GetApi(priority);

            var externalBooking = MappingService.Map<BookingEM>(booking);

            await api.Create(externalBooking);
        }
    }
}
