using System.Collections.Generic;

namespace TransportSystems.Frontend.External.Models.Transport
{
    public class VehicleParametersEM
    {
        public VehicleParametersEM()
        {
            Brands = new List<VehicleParameterEM>();
            Kinds = new List<VehicleParameterEM>();
            Capacities = new List<VehicleParameterEM>();
        }

        public ICollection<VehicleParameterEM> Brands { get; }

        public ICollection<VehicleParameterEM> Kinds { get; }

        public ICollection<VehicleParameterEM> Capacities { get; }
    }
}
