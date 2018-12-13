using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace TransportSystems.Frontend.External.Garages
{
    public interface IGaragesAPI
    {
        [Get("/api/garages/available_provinces")]
        [Headers("Authorization: Bearer")]
        Task<ICollection<string>> GetAvailableProvinces(string country);

        [Get("/api/garages/available_localities")]
        [Headers("Authorization: Bearer")]
        Task<ICollection<string>> GetAvailableLocalities(string country, string province);

        [Get("/api/garages/available_districts")]
        [Headers("Authorization: Bearer")]
        Task<ICollection<string>> GetAvailableDistricts(string country, string province, string locality);
    }
}
