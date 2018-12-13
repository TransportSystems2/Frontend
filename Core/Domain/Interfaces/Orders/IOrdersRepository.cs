using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Orders
{
    public interface IOrdersRepository
    {
        Task Create(BookingDM booking, RequestPriority priority);
    }
}
