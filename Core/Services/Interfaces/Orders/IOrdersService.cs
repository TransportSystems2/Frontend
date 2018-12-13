using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Orders
{
    public interface IOrdersService
    {
        Task Create(BookingDM booking, RequestPriority priority);
    }
}
