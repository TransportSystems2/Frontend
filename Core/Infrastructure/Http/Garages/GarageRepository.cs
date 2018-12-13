using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Interfaces.Garages;
using TransportSystems.Frontend.External.Garages;
using TransportSystems.Frontend.External.Interfaces;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Garages
{
    public class GarageRepository : ApiRepository<IGaragesAPI>, IGarageRepository
    {
        public GarageRepository(IAPIManager apiManager)
            : base(apiManager)
        {
        }

        public Task<ICollection<string>> GetAvailableProvinces(string country, RequestPriority priority)
        {
            var api = GetApi(priority);

            return api.GetAvailableProvinces(country);
        }

        public Task<ICollection<string>> GetAvailableLocalities(string country, string province, RequestPriority priority)
        {
            var api = GetApi(priority);

            return api.GetAvailableLocalities(country, province);
        }

        public Task<ICollection<string>> GetAvailableDistricts(string country, string province, string locality, RequestPriority priority)
        {
            var api = GetApi(priority);

            return api.GetAvailableDistricts(country, province, locality);
        }
    }
}