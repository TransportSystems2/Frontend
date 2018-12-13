using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.Transport;
using TransportSystems.Frontend.External.Transport;

namespace TransportSystems.Frontend.External.MockAPI.Transport
{
    public class MockVehicleAPI : IVehicleAPI
    {

        public async Task<VehicleParametersEM> GetVehicleParams()
        {
            await Task.Delay(1000);

            VehicleParametersEM result = new VehicleParametersEM();
            result.Brands.Add(new VehicleParameterEM { Id = 1, Name = "Toyota" });
            result.Brands.Add(new VehicleParameterEM { Id = 2, Name = "Nissan" });
            result.Brands.Add(new VehicleParameterEM { Id = 3, Name = "BMW" });

            result.Capacities.Add(new VehicleParameterEM { Id = 1, Name = "1 т" });
            result.Capacities.Add(new VehicleParameterEM { Id = 2, Name = "2 т" });
            result.Capacities.Add(new VehicleParameterEM { Id = 3, Name = "3 т" });

            result.Kinds.Add(new VehicleParameterEM { Id = 1, Name = "Ломаная платформа" });
            result.Kinds.Add(new VehicleParameterEM { Id = 2, Name = "Сдивжная платформа" });
            result.Kinds.Add(new VehicleParameterEM { Id = 3, Name = "Манипулятор" });

            return result;
        }
    }
}
