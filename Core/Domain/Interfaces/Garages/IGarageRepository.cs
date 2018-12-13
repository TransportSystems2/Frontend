using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Garages
{
    public interface IGarageRepository
    {
        Task<ICollection<string>> GetAvailableProvinces(string country, RequestPriority priority);

        Task<ICollection<string>> GetAvailableLocalities(string country, string province, RequestPriority priority);

        Task<ICollection<string>> GetAvailableDistricts(string country, string province, string locality, RequestPriority priority);
    }
}
