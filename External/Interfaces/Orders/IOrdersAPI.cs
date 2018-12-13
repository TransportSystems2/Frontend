using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.Models.Booking;

namespace TransportSystems.Frontend.External.Interfaces.Orders
{
    public interface IOrdersAPI
    {
        [Headers("Authorization: Bearer")]
        [Post("/api/orders/create")]
        Task Create(BookingEM booking);
    }
}
