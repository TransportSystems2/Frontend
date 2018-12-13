using System.Collections.Generic;

namespace TransportSystems.Frontend.Core.Domain.Core.Transport
{
    public class VehicleParametersDM
    {
        public VehicleParametersDM()
        {
            Brands = new List<VehicleParameterDM>();
            Kinds = new List<VehicleParameterDM>();
            Capacities = new List<VehicleParameterDM>();
        }

        public ICollection<VehicleParameterDM> Brands { get; }

        public ICollection<VehicleParameterDM> Kinds { get; }

        public ICollection<VehicleParameterDM> Capacities { get; }
    }
}
