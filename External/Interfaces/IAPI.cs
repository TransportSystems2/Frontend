using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.Models;

namespace TransportSystems.Frontend.External.Interfaces
{
    public interface IAPI
    {
        [Get("/api/ping/")]
        Task<string> Get(string request);
    }
}