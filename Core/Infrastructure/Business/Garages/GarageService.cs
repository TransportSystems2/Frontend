using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Interfaces.Garages;
using TransportSystems.Frontend.Core.Services.Interfaces.Garages;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Garages
{
    public class GarageService : IGarageService
    {
        public GarageService(IGarageRepository repository)
        {
            Repository = repository;
        }

        protected IGarageRepository Repository { get; }

        public Task<ICollection<string>> GetAvailableProvinces(string country, RequestPriority priority)
        {
            return Repository.GetAvailableProvinces(country, priority);
        }

        public Task<ICollection<string>> GetAvailableLocalities(string country, string province, RequestPriority priority)
        {
            return Repository.GetAvailableLocalities(country, province, priority);
        }

        public Task<ICollection<string>> GetAvailableDistricts(string country, string province, string locality, RequestPriority priority)
        {
            return Repository.GetAvailableDistricts(country, province, locality, priority);
        }
    }
}