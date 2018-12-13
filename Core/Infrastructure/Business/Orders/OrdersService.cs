using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Interfaces.Orders;
using TransportSystems.Frontend.Core.Services.Interfaces.Orders;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Orders
{
    public class OrdersService : IOrdersService
    {
        public OrdersService(IOrdersRepository ordersRepository)
        {
            OrdersRepository = ordersRepository;
        }

        protected IOrdersRepository OrdersRepository { get; }

        public async Task Create(BookingDM booking, RequestPriority priority)
        {
            await OrdersRepository.Create(booking, priority);
        }
    }
}
