using System.Collections.Generic;

namespace TransportSystems.Frontend.App.Models.Transport
{
    public class VehicleParametersM
    {
        public VehicleParametersM()
        {
            Brands = new List<VehicleParameterM>();
            Kinds = new List<VehicleParameterM>();
            Capacities = new List<VehicleParameterM>();
        }

        public ICollection<VehicleParameterM> Brands { get; }

        public ICollection<VehicleParameterM> Kinds { get; }

        public ICollection<VehicleParameterM> Capacities { get; }
    }
}